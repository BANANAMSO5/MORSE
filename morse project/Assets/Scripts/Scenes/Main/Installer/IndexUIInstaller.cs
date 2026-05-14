using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IndexUIInstaller : MonoInstaller
{
    [SerializeField] private RectTransform parent;

    public override void InstallBindings()
    {
        Container.Bind<RectTransform>()
                 .FromInstance(parent);

        Container.Bind<IPanelState>().To<ListPanelState>().AsSingle();
        Container.Bind<IPanelSlider>().To<PanelSlider>().AsSingle();
    }
}
