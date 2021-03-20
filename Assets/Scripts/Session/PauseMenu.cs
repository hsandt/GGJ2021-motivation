using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    /* Child references */
    
    [Tooltip("Blur Layer image using blur material")]
    public Image blurLayer;
    
    
    /* State */
    
    /// Temporary target texture for main camera used to render background with blur material when pause menu is open
    private RenderTexture tempBlurRenderTexture;


    private void Awake()
    {
        // create temporary texture matching current resolution
        // for now we cannot change resolution at runtime, so just reuse the render texture with that size every time
        // 16 bits depth buffer takes 5 MB instead of 7 MB for 24 bits, so use this (without depth though, you'd see nothing)
        tempBlurRenderTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        blurLayer.materialForRendering.SetTexture("_BlurTex", tempBlurRenderTexture);
        blurLayer.gameObject.SetActive(true);
    }
    
    
    private void OnDestroy()
    {
        // cleanup, probably not needed as temporary textures get destroyed when not used for a couple of frames,
        // but avoids keeping them around in the editor (otherwise they spam Profiler > Memory > Take Sample Playmode)
        if (blurLayer && blurLayer.materialForRendering)
        {
            blurLayer.materialForRendering.SetTexture("_BlurTex", null);
        }

        if (Camera.main)
        {
            Camera.main.targetTexture = null;
        }
        
        RenderTexture.ReleaseTemporary(tempBlurRenderTexture);
    }

    public void OnShow()
    {
        Camera.main.targetTexture = tempBlurRenderTexture;
    }
    
    public void OnHide()
    {
        Camera.main.targetTexture = null;
    }

    // Button callback
    public void BackToMainMenu()
    {
        SessionManager.Instance.BackToMainMenu();
    }
    
    // Button callback
    public void BackToGame()
    {
        SessionManager.Instance.ResumeGame();
    }
}
