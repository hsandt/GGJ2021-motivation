using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TutorialMessage
{
    public string senderName;
    
    public string subjectText;
    
    [TextArea(3, 20)]
    public string messageText;
}
