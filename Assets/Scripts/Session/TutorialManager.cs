using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommonsPattern;

public class TutorialManager : SingletonManager<TutorialManager>
{
    /* Cached data references */

    private TutorialData m_tutorialData;
    
    
    protected override void Init()
    {
        m_tutorialData = Resources.Load<TutorialData>("Tutorial/TutorialData");
    }
}
