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
        var rect = monoPanel.GetComponent<RectTransform>();
        // _stocker.Add(rect);
    }

    public void Period()
    {
        
    }
}
