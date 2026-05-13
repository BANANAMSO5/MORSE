using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPanelAligner : IPanelAligner
{
    private const float offsetX = 150.0f;

    public void Align(List<RectTransform> rects)
    {
        foreach (var rect in rects)
        {
            rect.anchoredPosition += Vector2.right * offsetX;
        }
    }
}
