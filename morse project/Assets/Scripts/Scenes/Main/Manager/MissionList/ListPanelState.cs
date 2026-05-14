using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ListPanelState : IPanelState
{
    public RectTransform Rect { get; private set; }
    public bool IsOpen { get; set; }
    public float Width => Rect.rect.width;
    public float Height => Rect.rect.height;

    [Inject]
    public void Construct(RectTransform rect)
    {
        Rect = rect;
        IsOpen = true;
    }
}
