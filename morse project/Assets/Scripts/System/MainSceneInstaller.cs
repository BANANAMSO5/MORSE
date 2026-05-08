using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject dotPanelPrefab;
    [SerializeField] private GameObject dashPanelPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<SignalPanel, DotSignalPanelFactory>()
            .FromComponentInNewPrefab(dotPanelPrefab)
            .AsTransient();

        Container.BindFactory<SignalPanel, DashSignalPanelFactory>()
            .FromComponentInNewPrefab(dashPanelPrefab)
            .AsTransient();
    }
}
