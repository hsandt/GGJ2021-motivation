using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsHelper;

public abstract class GaugeToken<TGameplayValueType> : Gauge<TGameplayValueType>
{
    [Header("Asset references")]
    
    [Tooltip("Token prefab")]
    public GameObject tokenPrefab;
    
    
    [Header("Child references")]
    
    [Tooltip("Parent containing the token objects. Typically a Horizontal Layout.")]
    public Transform tokenParent;

    
    /* Child components */

    /// List of Token components in same order as children
    /// For faster access than getting child of tokenParent, then getting Token component
    private readonly List<Token> m_Tokens = new List<Token>();
    
    
    /* Cached parameters */

    /// Cached count of tokens to show, derived from gameplay value data max value (each token represents 1)
    private int m_CachedActiveTokensCount;
    
    
    protected override void OnSetTrackedGameplayValue()
    {
        InitTokens();
    }
    
    protected override void RefreshGaugeFillSize()
    {
        base.RefreshGaugeFillSize();

        int filledTokensCount = Mathf.FloorToInt(m_TrackedGameplayValue.CurrentValue);
        float tokenInProgressRatio = m_TrackedGameplayValue.CurrentValue % 1f;
        
        // first, set all tokens completely filled
        for (int i = 0; i < filledTokensCount; i++)
        {
            m_Tokens[i].SetFilled();
        }

        // second, if the value is not an integer, set partial fill ratio for the token in progress
        // (the one just after the last filled token)
        if (tokenInProgressRatio > 0f)
        {
            // note that the index won't be out-of-bounds as long as CurrentValue <= MaxValue
            m_Tokens[filledTokensCount].SetFillRatio(tokenInProgressRatio);
        }
        
        for (int i = filledTokensCount + 1; i < m_Tokens.Count; i++)
        {
            m_Tokens[i].SetFillRatio(0f);
        }
    }

    private void InitTokens()
    {
        // We recommend only using integer max values, since each token represents 1.
        // But in case it's not, note that the required token count is Ceil(maxValue).
        // For instance, if max value is 2.5, we show 3 tokens, even though the last one can only be half-filled.
        GameplayValueParameter gameplayValueParameter = m_TrackedGameplayValue.Data.parameterPerDifficultyLevel[SessionManager.Instance.difficultySetting.level];
        m_CachedActiveTokensCount = Mathf.CeilToInt(gameplayValueParameter.maxValue);
        
        // First, create enough tokens for the gameplay value data
        // There may already be one or more tokens under tokenParent to visualize better
        // in the editor, so only add what you need, i.e. extra tokens besides the initial count.
        // We assume all children of tokenParent are actually tokens, so just count them.
        int initialTokensCount = tokenParent.childCount;
        for (int i = initialTokensCount; (float)i < m_CachedActiveTokensCount; i++)
        {
            Instantiate(tokenPrefab, tokenParent);
        }

        // Second, disable any extra tokens (possible if we tested many tokens in the editor)
        for (int i = m_CachedActiveTokensCount; i < initialTokensCount; i++)
        {
            tokenParent.GetChild(i).gameObject.SetActive(false);
        }

        // Third, register and setup each token to reflect the gauge value
        for (int i = 0; i < m_CachedActiveTokensCount; i++)
        {
            // get token script
            Transform tokenTr = tokenParent.GetChild(i);
            var token = tokenTr.GetComponentOrFail<Token>();
            
            // register token
            m_Tokens.Add(token);
            
            // init token
            token.Init();
        }
    }
}
