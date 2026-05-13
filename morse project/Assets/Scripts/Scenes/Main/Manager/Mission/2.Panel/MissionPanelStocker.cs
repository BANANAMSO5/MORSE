using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissionPanelStocker : IPanelStocker
{
    private const int MaxCount = 7;
    private Queue<RectTransform> _queue = new Queue<RectTransform>();
    private IPanelDisplayer _displayer;
    private IObjectService _objectService;

    [Inject]
    public void Construct(IPanelDisplayer displayer)
    {
        _displayer = displayer;
        _displayer.OnFinished += ShowPanel;
    }

    public void Add(RectTransform panel)
    {
        if (panel == null) return;
        _queue.Enqueue(panel);
        ShowPanel();
    }

    public void ShowPanel()
    {
        if (_queue.Count == 0 || _displayer.IsProcessing) return;

        // 送る個数を決める（キューにある個数と最大バッチの小さい方）
        int sendCount = Mathf.Min(MaxCount, _queue.Count);
        List<RectTransform> toSend = new List<RectTransform>();

        for (int i = 0; i < sendCount; i++)
        {
            toSend.Add(_queue.Dequeue());
        }

        _displayer.Display(toSend);
    }
}
