using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MIssionUIInstaller : MonoInstaller
{
    [SerializeField] private Transform parent;

    public override void InstallBindings()
    {
        Container.Bind<Transform>()
            .FromInstance(parent);

        Container.Bind<IPanelAssigner>().To<MissionPanelAssigner>().AsSingle();
        Container.Bind<IPanelStocker>().To<MissionPanelStocker>().AsSingle();
        Container.Bind<IPanelDisplayer>().To<MissionPanelDisplayer>().AsSingle();
    }
}
