using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private ObjectService objectService;
    [SerializeField] private GameObject dotPanelPrefab;
    [SerializeField] private GameObject dashPanelPrefab;

    public override void InstallBindings()
    {
        Container.Bind<IInputManager>()
            .To<InputManager>()
            .FromInstance(inputManager)
            .AsSingle();
        
        Container.Bind<IObjectService>()
            .To<ObjectService>()
            .FromInstance(objectService)
            .AsSingle();

        Container.BindFactory<SignalPanel, DotSignalPanelFactory>()
            .FromComponentInNewPrefab(dotPanelPrefab)
            .AsTransient();

        Container.BindFactory<SignalPanel, DashSignalPanelFactory>()
            .FromComponentInNewPrefab(dashPanelPrefab)
            .AsTransient();
        


        
        Container.Bind<IPanelAssigner>().To<PanelAssigner>().AsSingle();
        Container.Bind<IPanelStocker>().To<PanelStocker>().AsSingle();
        Container.Bind<IPanelAligner>().To<PanelAligner>().AsSingle();

        Container.Bind<ITextChanger>().To<TextChanger>().AsSingle();

        // mission
        
    }
}
