using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureCommandController : MonoBehaviour
{
    [Header("Asset references")]

    [Tooltip("Hover Material")]
    public Material hoverMaterial;

    private Material m_OriginalMaterial;

    
    [Header("Children references")]

    [Tooltip("Mesh Renderer")]
    public MeshRenderer meshRenderer;


    [Header("Parameters")]

    [Tooltip("Array of activity data available for this furniture")]
    public ActivityData[] activityDataArray;


    private void Awake()
    {
        m_OriginalMaterial = meshRenderer.material;
    }


    // OnPointerClick callback
    public void ShowCommandPopUpForAvailableActivities()
    {
        ActivityManager.Instance.ShowCommandPopUp(activityDataArray);
    }
    
    // OnPointerEnter callback
    public void OnFurniturePointerEnter()
    {
        meshRenderer.material = hoverMaterial;
    }
    
    // OnPointerExit callback
    public void OnFurniturePointerExit()
    {
        meshRenderer.material = m_OriginalMaterial;
    }
}
