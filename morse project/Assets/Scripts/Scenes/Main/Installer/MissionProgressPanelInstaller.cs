using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MissionProgressPanelInstaller : Installer<MissionProgressPanelData, MissionProgressPanelInstaller>
{
    private MissionProgressPanelData _data;

    [Inject]
    public void Construct(MissionProgressPanelData data)
    {
        _data = data;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(_data).AsSingle();

        Container.Bind<Slider>()
            .FromComponentInChildren().AsSingle();
            
        Container.Bind<TextMeshProUGUI>()
            .FromComponentsInChildren(includeInactive: true)
            .AsCached();

        Container.Bind<IPanel>().To<MissionProgressPanel>().FromComponentInHierarchy().AsSingle();
    }
}
