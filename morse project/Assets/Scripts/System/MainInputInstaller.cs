using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainInputInstaller : MonoInstaller
{
    [SerializeField] private Transform parent;

    public override void InstallBindings()
    {
        Container.Bind<IInputManager>()
                .To<InputManager>()
                .FromComponentInHierarchy().AsSingle();

        Container.Bind<IPanelAssigner>()
                .To<PanelAssigner>()
                .FromComponentInHierarchy().AsSingle();

        Container.Bind<IPanelStocker>()
                .To<PanelStocker>()
                .FromComponentInHierarchy().AsSingle();

        Container.Bind<IPanelAligner>()
                .To<PanelAligner>()
                .FromComponentInHierarchy().AsSingle();
        
        Container.Bind<Transform>()
            .FromInstance(parent);
    }
}
