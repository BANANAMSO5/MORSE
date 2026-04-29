using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalUIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Canvasにアタッチする想定
        Container.Bind<ISignalUIManager>().To<SignalUIManager>()
            .FromComponentOnRoot().AsSingle();
    }
}
