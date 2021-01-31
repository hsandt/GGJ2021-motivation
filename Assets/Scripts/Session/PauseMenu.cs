using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
