using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerSystem>()
            .FromComponentOnRoot()
            .AsSingle();

        var playerSystem = Container.Resolve<PlayerSystem>();
        bool iscpu = playerSystem.isCPU;

        if (!iscpu)
        {
            Container.Bind<IInputManager>()
                .To<InputManager>()
                .FromComponentInHierarchy()
                .AsCached();
        }
        else
        {
            Container.Bind<IInputManager>()
                .To<CPUInputManager>()
                .FromComponentInHierarchy()
                .AsCached();
        }
    }
}
