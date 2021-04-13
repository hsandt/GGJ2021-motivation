using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    [Tooltip("Token Fill Mask Rect Transform")]
    public RectTransform fillMaskRectTransform;
    
    public void Init()
    {
        // Set width to match height (token shape must be square), to avoid non-uniform scaling if we
        // changed the height of the gauge horizontal layout containing the token
        RectTransform rectTransform = (RectTransform) transform;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.y, rectTransform.sizeDelta.y);
    }

    public void SetFilled()
    {
        // We may want to show filled tokens with a brighter color, glow, etc.
        // hence the distinct method. For now, we just apply full mask.
        SetFillRatio(1f);
    }
    
    public void SetFillRatio(float fillRatio)
    {
        fillMaskRectTransform.anchorMax = new Vector2(fillRatio, 1f);
    }
}
