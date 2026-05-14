using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelState
{
    RectTransform Rect { get; }
    bool IsOpen { get; set; }
    float Width => Rect.rect.width;
    float Height => Rect.rect.height;
}
