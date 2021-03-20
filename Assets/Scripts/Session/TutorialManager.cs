using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsPattern;

/// Actually handles tutorial and success/failure messages
public class TutorialManager : SingletonManager<TutorialManager>
{
    [Header("External references")]

    [Tooltip("Tutorial widget")]
    public CanvasMessage canvasMessage;
        
    
    /* Cached data references */

    private TutorialData m_TutorialData;
    
    
    /* State */

    private bool m_IsShowingMessage;
    public bool IsShowingMessage => m_IsShowingMessage;
        
    
    protected override void Init()
    {
        m_TutorialData = Resources.Load<TutorialData>("Tutorial/TutorialData");
    }

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        m_IsShowingMessage = false;
        canvasMessage.gameObject.SetActive(false);
    }

    public void ShowMessage(MessageEnum messageType)
    {
        m_IsShowingMessage = true;
        canvasMessage.gameObject.SetActive(true);
        
        TutorialMessage message = m_TutorialData.tutorialMessages[(int)messageType];
        canvasMessage.ShowMessage(message.senderName, message.subjectText, message.messageText);
    }
    
    public void HideMessage()
    {
        m_IsShowingMessage = false;
        canvasMessage.gameObject.SetActive(false);
    }
}
