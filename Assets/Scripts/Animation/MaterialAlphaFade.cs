using System.Collections;
using System.Collections.Generic;
using CommonsHelper;
using UnityEngine;

public class MaterialAlphaFade : MonoBehaviour
{
    [Tooltip("List of renderers for which material instances should be faded in/out during pose transitions")]
    public Renderer[] renderers;

    [Tooltip("Fading alpha, must be set to 0/1 by animation for pose transition (let Animator Graph handle transition)")]
    public float alpha;

    /// Track last alpha to only change material color when dirty
    private float m_LastAlpha;

    private void Awake()
    {
        // material instance should be visible on start
        m_LastAlpha = 1f;
    }
    
    private void Update()
    {
        if (m_LastAlpha != alpha)
        {
            m_LastAlpha = alpha;
        
            foreach (Renderer renderer in renderers)
            {
                // we assume single material per renderer
                // if adding more, iterate on materials instead
                renderer.material.color = renderer.material.color.ToAlpha(alpha);
            }
        }
    }
}
