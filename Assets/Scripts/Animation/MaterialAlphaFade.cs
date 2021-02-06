using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CommonsHelper;
using UnityEngine;

public class MaterialAlphaFade : MonoBehaviour
{
    /* Children references */
    
    [Tooltip("List of slaves for which material instances should be faded in/out during pose transitions")]
    public MaterialAlphaFadeOnMesh[] slaves;
    
    
    /* State */
    
    [Tooltip("Fading alpha, exceptionally public as must be set to 0/1 by animation for pose transition " +
             "(let Animator Graph handle transition). Value set is used as initial value but animation may overwrite " +
             "it on Start anyway.")]
    public float alpha;
    
    /// Track last alpha since refreshing slaves so we only update them when needed
    private float m_LastAlpha;
    
    
    private void Awake()
    {
        RefreshSlavesAlpha();
    }
    
    private void Update()
    {
        if (m_LastAlpha != alpha)
        {
            RefreshSlavesAlpha();
        }
    }

    private void RefreshSlavesAlpha()
    {
        foreach (MaterialAlphaFadeOnMesh slave in slaves)
        {
            slave.alpha = alpha;
        }
        
        m_LastAlpha = alpha;
    }
}
