using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MissionProgressPanelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Slider>()
            .FromComponentInChildren().AsSingle();
            
        Container.Bind<TextMeshProUGUI>()
            .FromComponentInChildren().AsSingle();
    }
}
