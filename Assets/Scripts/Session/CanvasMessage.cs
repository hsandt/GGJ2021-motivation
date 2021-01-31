using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasMessage : MonoBehaviour
{
    [Tooltip("Sender Name Widget")]
    public TextMeshProUGUI senderNameWidget;

    [Tooltip("Subject Text Widget")]
    public TextMeshProUGUI subjectTextWidget;

    [Tooltip("Message Text Widget")]
    public TextMeshProUGUI messageTextWidget;

    public void ShowMessage(string senderName, string subjectText, string messageText)
    {
        senderNameWidget.text = senderName;
        subjectTextWidget.text = subjectText;
        messageTextWidget.text = messageText;
    }
    
    public void HideMessage()
    {
        TutorialManager.Instance.HideMessage();
    }
}