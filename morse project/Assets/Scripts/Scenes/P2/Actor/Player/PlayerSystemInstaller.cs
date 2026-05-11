using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSystemInstaller : MonoInstaller
{
    [SerializeField] private bool isCPU;

    public override void InstallBindings()
    {
        // CPU操作を切り替え
        if (!isCPU)
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
