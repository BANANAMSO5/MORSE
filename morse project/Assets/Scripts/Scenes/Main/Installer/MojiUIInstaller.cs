using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MojiUIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CanvasGroup>()
            .FromComponentInChildren().AsSingle();
            
        Container.Bind<TextMeshProUGUI>()
            .FromComponentInChildren().AsSingle();
    }
}
