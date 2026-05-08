using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelAssigner : IPanelAssigner
{
    private IPanelStocker _stocker;

    [Inject]
    public void Construct(IPanelStocker stocker)
    {
        _stocker = stocker;
    }
    
    public void Add(SignalPanel panel, Transform parent)
    {
        panel.transform.SetParent(parent, false);
        var rect = panel.GetComponent<RectTransform>();
        _stocker.Add(rect);
    }

    public void Period()
    {
        
    }
}
