using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissionUIManager : MonoBehaviour, IMissionUIManager
{
    private MissionProgressPanelFactory _factory;
    private IPanelAssigner _panelAssigner;
    private Transform _parent;

    [Inject]
    public void Construct(
        MissionProgressPanelFactory factory,
        IPanelAssigner panelAssigner,
        Transform parent
    )
    {
        _factory = factory;
        _panelAssigner = panelAssigner;
        _parent = parent;
    }

    public void AddMissionProgress()
    {
        IPanel panel = _factory.Create(0.5f);
        _panelAssigner.Add(panel, _parent);
    }
}
