using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelStocker : IPanelStocker
{
    private const int MaxCount = 20;
    private List<RectTransform> _panels = new();
    private IPanelAligner _aligner;
    private IObjectService _objectService;

    [Inject]
    public void Construct(
        IPanelAligner aligner,
        IObjectService objectService
    )
    {
        _aligner = aligner;
        _objectService = objectService;
    }

    public void Add(RectTransform panel)
    {
        _aligner.Align(_panels);
        
        // 新規を先頭に追加
        _panels.Insert(0, panel);

        // 最大数超過なら末尾削除
        if (_panels.Count > MaxCount)
        {
            var oldest = _panels[^1];

            _panels.RemoveAt(_panels.Count - 1);

            _objectService.DestroyObject(oldest.gameObject);
        }

    }
}
