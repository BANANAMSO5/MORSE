using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private MissionUIManager mssionManager;
    [SerializeField] private ObjectService objectService;
    [SerializeField] private GameObject dotPanelPrefab;
    [SerializeField] private GameObject dashPanelPrefab;
    [SerializeField] private GameObject missionPanelPrefab;

    public override void InstallBindings()
    {
        Container.Bind<IInputManager>()
            .To<InputManager>()
            .FromInstance(inputManager)
            .AsSingle();

        Container.Bind<IMissionUIManager>()
            .To<MissionUIManager>()
            .FromInstance(mssionManager)
            .AsSingle();
        
        Container.Bind<IObjectService>()
            .To<ObjectService>()
            .FromInstance(objectService)
            .AsSingle();

        Container.BindFactory<IPanel, DotSignalPanelFactory>()
            .To<SignalPanel>()
            .FromComponentInNewPrefab(dotPanelPrefab)
            .AsTransient();

        Container.BindFactory<IPanel, DashSignalPanelFactory>()
            .To<SignalPanel>()
            .FromComponentInNewPrefab(dashPanelPrefab)
            .AsTransient();
        
        Container.BindFactory<MissionProgressPanelData, IPanel, MissionProgressPanelFactory>()
            .FromSubContainerResolve()
            .ByNewPrefabInstaller<MissionProgressPanelInstaller>(missionPanelPrefab);

        

        Container.Bind<IDataSaver>().To<DataSaver>().AsSingle();
        Container.Bind<IDataLoader>().To<DataLoader>().AsSingle();
        Container.Bind<IDataEncrypter>().To<DataEncrypter>().AsSingle();
        Container.Bind<IDataDecrypter>().To<DataDecrypter>().AsSingle();
        Container.Bind<IHMACManager>().To<HMACManager>().AsSingle();
        
        Container.Bind<ISaveDataManager>().To<SaveDataManager>().AsSingle();
        Container.Bind<IAutoSaveManager>().To<AutoSaveManager>().AsSingle();
        Container.Bind<IInitLoadManager>().To<InitLoadManager>().AsSingle();

        
        Container.BindInterfacesTo<GameInitializer>().AsSingle();
        
    }
}
