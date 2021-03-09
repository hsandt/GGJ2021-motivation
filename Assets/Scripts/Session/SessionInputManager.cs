using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionInputManager : MonoBehaviour
{
    private void OnTogglePause()
    {
        // if any command popup is open, close it instead of showing Pause Menu
        // (we assume Pause Menu is not shown on top of command popup)
        if (ActivityManager.Instance.commandPopUp.gameObject.activeSelf)
        {
            ActivityManager.Instance.HideCommandPopUp();
        }
        else
        {
            SessionManager.Instance.TogglePause();
        }
    }
    
#if UNITY_EDITOR
    // Input action callback
    private void OnCheatFinishWriting()
    {
        SessionManager.Instance.CheatFinishWriting();
    }
#endif
}
