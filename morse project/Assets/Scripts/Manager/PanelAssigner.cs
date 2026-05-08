using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelAssigner : MonoBehaviour, IPanelAssigner
{
    private const int MaxCount = 20;
    private List<SignalPanel> _panels = new();
    private Transform _parentCanvas;
    private IPanelStocker _stocker;

    [Inject]
    public void Construct(
        Transform parentCanvas,
        IPanelStocker stocker
    )
    {
        _parentCanvas = parentCanvas;
        _stocker = stocker;
    }
    
    public void Add(SignalPanel panel)
    {
        panel.transform.SetParent(_parentCanvas, false);
        var rect = panel.GetComponent<RectTransform>();
        _stocker.Add(rect);
    }

    public void Period()
    {
        
    }
}
