using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionInputManager : MonoBehaviour
{
    private void OnTogglePause()
    {
        SessionManager.Instance.TogglePause();
    }
}
