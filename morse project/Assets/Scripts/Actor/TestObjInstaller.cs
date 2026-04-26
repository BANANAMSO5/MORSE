using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestObjInstaller : Installer<int, TestObjInstaller>
{
    readonly int _id;

    public TestObjInstaller(int id)
    {
        _id = id;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(_id);

        Container.Bind<TestObj>()
            .FromComponentOnRoot()
            .AsSingle();

        Container.Bind<TestObjB>()
            .FromComponentOnRoot()
            .AsSingle();
    }
}
