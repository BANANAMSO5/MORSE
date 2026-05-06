using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputManager>()
                .To<InputManager>()
                .FromComponentInHierarchy().AsSingle();
    }
}
