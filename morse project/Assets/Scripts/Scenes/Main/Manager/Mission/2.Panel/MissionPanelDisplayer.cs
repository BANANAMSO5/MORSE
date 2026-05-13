using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissionPanelDisplayer : IPanelDisplayer
{
    public bool IsProcessing { get; private set; } = false;
    public event Action OnFinished;
    private float displaytime = 5f;
    private IObjectService _objectService;

    [Inject]
    public void Construct(IObjectService objectService)
    {
        _objectService = objectService;
    }

    public void Display(List<RectTransform> rects)
    {
        if (IsProcessing || rects == null || rects.Count == 0) return;
        _objectService.StartProcess(ProcessRects(rects));
    }

    IEnumerator ProcessRects(List<RectTransform> rects)
    {
        IsProcessing = true;
        float offsetY = 0;

        // 縦に並べる
        for (int i = 0; i < rects.Count; i++)
        {
            rects[i].anchoredPosition = new Vector2(0, -offsetY);
            rects[i].gameObject.SetActive(true);

            offsetY += rects[i].rect.height + 5f;
        }

        // 1秒待つ
        yield return new WaitForSeconds(displaytime);

        // 削除
        foreach (var rect in rects)
        {
            if (rect != null)
                _objectService.DestroyObject(rect.gameObject);
        }

        IsProcessing = false;
        OnFinished?.Invoke();
    }
}
