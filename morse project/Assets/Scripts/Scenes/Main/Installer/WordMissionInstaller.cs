using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordMissionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IWordChecker>()
            .To<WordChecker>()
            .AsSingle();
    }
}
