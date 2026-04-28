using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerUIInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Canvasにアタッチする想定
        Container.Bind<TextUIManager>()
            .FromComponentOnRoot()
            .AsSingle();

        // Canvas配下から取得
        Container.Bind<TextMeshProUGUI>()
            .FromComponentInChildren().AsSingle();
        
        Container.Bind<CanvasGroup>()
            .FromComponentInChildren().AsSingle();
    }
}
