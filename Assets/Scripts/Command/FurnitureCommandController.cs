using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCommandController : MonoBehaviour
{
    [Header("Asset references")]

    [Tooltip("Hover Material")]
    public Material hoverMaterial;

    private Material m_OriginalMaterial = null;

    
    [Header("Children references")]

    [Tooltip("Mesh Renderer")]
    public MeshRenderer meshRenderer;


    [Header("Parameters")]

    [Tooltip("Array of activity data available for this furniture")]
    public ActivityData[] activityDataArray;


    // OnPointerClick callback
    public void ShowCommandPopUpForAvailableActivities()
    {
        ActivityManager.Instance.ShowCommandPopUp(activityDataArray);
    }
    
    // OnPointerEnter callback
    public void OnFurniturePointerEnter()
    {
        // FIXME: prevent interactions after scene has been loaded + some delay
        // to prevent hovering item on start by accident and storing the wrong material
        // Alternatively, define restore material from the current state (visible or not)
        // Ultimately we won't be able to hover during transitions at all, so restore material
        // will always be some opaque material (maybe set as param of this script;
        // we can also save it on Awake once and for all, but we must make sure the Animator
        // starts with the right material)
        
        // store original material to restore it after hover
        // this only works if there is no way for base material to change
        // while still hovering, and it should be the case
        // (the only way to change base material should be to start an activity
        // causing a fading transition with alpha material, and interactions
        // should be prevented during that time)
        m_OriginalMaterial = meshRenderer.material;
        meshRenderer.material = hoverMaterial;
    }
    
    // OnPointerExit callback
    public void OnFurniturePointerExit()
    {
        if (m_OriginalMaterial)
        {
            meshRenderer.material = m_OriginalMaterial;
        }
    }
}
