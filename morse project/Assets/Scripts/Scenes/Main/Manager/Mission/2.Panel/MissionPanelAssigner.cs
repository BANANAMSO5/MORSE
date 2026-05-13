using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissionPanelAssigner : IPanelAssigner
{
    private IPanelStocker _stocker;

    [Inject]
    public void Construct(IPanelStocker stocker)
    {
        _stocker = stocker;
    }
    
    public void Add(IPanel panel, Transform parent)
    {
        var monoPanel = panel as MonoBehaviour;
        monoPanel.transform.SetParent(parent, false);

        // 一旦非表示にしてから渡す
        var rect = monoPanel.GetComponent<RectTransform>();
        rect.gameObject.SetActive(false);
        _stocker.Add(rect);
    }

    public void Period()
    {
        
    }
}
