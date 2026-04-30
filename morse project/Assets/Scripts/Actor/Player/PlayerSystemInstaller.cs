using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSystemInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputManager>()
            .To<InputManager>()
            .FromComponentInHierarchy()
            .AsCached();
    }
}
