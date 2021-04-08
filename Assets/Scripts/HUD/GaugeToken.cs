using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class GaugeToken<TGameplayValueType> : Gauge<TGameplayValueType>
{
    [Header("Child references")]
    
    [Tooltip("Gauge Fill Rect Transform")]
    public RectTransform fillRectTransform;

    protected override void RefreshGaugeFillSize()
    {
        base.RefreshGaugeFillSize();

        // Old code was moving anchor, but now we should use the Rect Mask 2D component width
        // to have a rectangle edge. However this uses a px width so we must calculate value from ratio. 
        fillRectTransform.anchorMax = new Vector2(m_TrackedGameplayValue.GetRatio(), 1f);
    }
}
