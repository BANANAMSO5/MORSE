using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalPanelAssigner : IPanelAssigner
{
    private IPanelStocker _stocker;

    [Inject]
    public void Construct(IPanelStocker stocker)
    {
        _stocker = stocker;
    }
    
    public void Add(IPanel panel, Transform parent)
    {
        var _panel = panel as MonoBehaviour;
        _panel.transform.SetParent(parent, false);
        var rect = _panel.GetComponent<RectTransform>();
        _stocker.Add(rect);
    }

    public void Period()
    {
        
    }
}
