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

    private TutorialData m_tutorialData;
    
    
    protected override void Init()
    {
        m_tutorialData = Resources.Load<TutorialData>("Tutorial/TutorialData");
    }

    private void Start()
    {
        canvasMessage.gameObject.SetActive(false);
    }


    public void ShowMessage(MessageEnum messageType)
    {
        canvasMessage.gameObject.SetActive(true);
        
        TutorialMessage message = m_tutorialData.tutorialMessages[(int)messageType];
        canvasMessage.ShowMessage(message.senderName, message.subjectText, message.messageText);
    }
    
    public void HideMessage()
    {
        canvasMessage.gameObject.SetActive(false);
    }
}
