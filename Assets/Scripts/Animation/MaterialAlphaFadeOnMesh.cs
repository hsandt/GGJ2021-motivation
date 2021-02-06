using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using CommonsHelper;
using UnityEngine;

public class MaterialAlphaFadeOnMesh : MonoBehaviour
{
    /* Asset references */
    
    [Tooltip("Material used for opaque rendering (alpha = 1)")]
    public Material materialOpaque;
    
    [Tooltip("Material used for transparent rendering (alpha < 1)")]
    public Material materialTransparent;
    
    
    /* Sibling components */

    private Renderer m_Renderer;
    
    
    /* State */
    
    /// Fading alpha, exceptionally public but hidden as it must be set by MaterialAlphaFade on parent object
    /// (a kind of controller), itself driven by Animator Graph transition, but not animated itself.
    [HideInInspector]
    public float alpha;
    
    /// Track last alpha on material to only change material color when dirty
    private float m_MaterialAlpha;

    
    private void Awake()
    {
        m_Renderer = this.GetComponentOrFail<Renderer>();
    }

    private void Start()
    {
        // only in Start so any default value set in Awake in parent MaterialAlphaFade is guaranteed to have been
        // transfered to slave
        RefreshMaterialAlpha();
    }
    
    private void Update()
    {
        if (m_MaterialAlpha != alpha)
        {
            RefreshMaterialAlpha();
        }
    }

    private void RefreshMaterialAlpha()
    {
        if (alpha < 1f)
        {
            if (m_MaterialAlpha >= 1f)
            {
                // we were opaque, switch to transparent material
                m_Renderer.material = materialTransparent;
            }
            
            // in any case, set material alpha to new value
            // we assume single material per renderer
            // if adding more, iterate on materials instead
            // Note that we don't use materialTransparent directly since we modify the material instance, not
            // the shared asset
            m_Renderer.material.color = m_Renderer.material.color.ToAlpha(alpha);
        }
        else if (m_MaterialAlpha < 1f)
        {
            // we were transparent, switch to opaque material
            // no need to change color, opaque material always keeps color with alpha = 1
            m_Renderer.material = materialOpaque;
        }
        
        m_MaterialAlpha = alpha;
    }
}
