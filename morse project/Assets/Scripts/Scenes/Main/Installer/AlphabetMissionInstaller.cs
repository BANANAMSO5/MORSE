using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AlphabetMissionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IFactorChecker>()
            .To<AlphabetChecker>()
            .AsSingle();
    }
}
