using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleSignalUIInstaller : MonoInstaller
{
    [SerializeField] private Transform parent;


    public override void InstallBindings()
    {
        Container.Bind<Transform>()
            .FromInstance(parent);
    }
}
