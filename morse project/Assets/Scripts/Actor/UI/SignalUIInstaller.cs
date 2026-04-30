using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalUIInstaller : MonoInstaller
{
    [SerializeField] private Transform signalPanel1Transform;
    [SerializeField] private Transform signalPanel2Transform;
    [SerializeField] private Transform signalPanel3Transform;
    [SerializeField] private Transform signalPanel4Transform;

    public override void InstallBindings()
    {
        // Canvasにアタッチする想定
        Container.Bind<ISignalUIManager>().To<SignalUIManager>()
            .FromComponentOnRoot().AsSingle();
        
        Container.Bind<SignalPanelArea>()
            .FromInstance(new SignalPanelArea(
                signalPanel1Transform,
                signalPanel2Transform,
                signalPanel3Transform,
                signalPanel4Transform))
            .AsSingle();
    }
}
