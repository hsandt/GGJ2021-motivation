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
