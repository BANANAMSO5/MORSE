using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAligner : IPanelAligner
{
    private const float offsetX = 150.0f;
    private const float duration = 0.25f;

    // public IEnumerator Align(List<RectTransform> panels)
    // {
    //     if (panels == null || panels.Count == 0)
    //         yield return null;

    //     float time = 0;

    //     List<Vector2> start = new();

    //     foreach (var ui in panels)
    //     {
    //         start.Add(ui.GetComponent<RectTransform>().anchoredPosition);
    //     }

    //     while (time < duration)
    //     {
    //         float t = time / duration;

    //         for (int i = 0; i < panels.Count; i++)
    //         {
    //             var rect = panels[i].GetComponent<RectTransform>();

    //             Vector2 target = start[i] - new Vector2(offsetX, 0);

    //             rect.anchoredPosition = Vector2.Lerp(start[i], target, t);
    //         }

    //         time += Time.deltaTime;
    //         yield return null;
    //     }
    // }

    public void Align(List<RectTransform> rects)
    {
        foreach (var rect in rects)
        {
            rect.anchoredPosition += Vector2.right * offsetX;
        }
    }
}
