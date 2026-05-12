using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseMissionInstaller : MonoInstaller
{
    [SerializeField] private TextAsset missionCsv;

    public override void InstallBindings()
    { 
        Container.Bind<IMissionTracker>()
            .To<MissionTracker>()
            .AsSingle();

        Container.Bind<IMissionResolver>()
            .To<MissionResolver>()
            .AsSingle();

        Container.Bind<IMissionCsvLoader>()
            .To<MissionCsvLoader>()
            .AsSingle();

        Container.Bind<IMissionCsvHolder>()
            .To<MissionCsvHolder>()
            .FromInstance(new MissionCsvHolder(missionCsv))
            .AsSingle();
    }
}
