using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject dotPanelPrefab;
    [SerializeField] private GameObject dashPanelPrefab;
    [SerializeField] private Transform signalPanel1Transform;
    [SerializeField] private Transform signalPanel2Transform;
    [SerializeField] private Transform signalPanel3Transform;
    [SerializeField] private Transform signalPanel4Transform;

    [SerializeField] private Canvas pausePanel;
    

    [SerializeField] private GameObject testPrefab;
    public override void InstallBindings()
    {
        // ゲーム内オブジェクト
        Container.Bind<Player>()
            .WithId("player1")
            .FromInstance(player1);
        Container.Bind<Player>()
            .WithId("player2")
            .FromInstance(player2);
        // Container.BindFactory<Bullet, BulletFactory>()
        //     .FromComponentInNewPrefab(bullet)
        //     .AsTransient();
        // Container.Bind<CanvasGroup>()
        //     .FromInstance(canvasGroup);
        // Container.Bind<TextMeshProUGUI>()
        //     .FromInstance(text);
        Container.Bind<Canvas>()
            .FromInstance(pausePanel);

        Container.Bind<SignalPanelArea>()
            .FromInstance(new SignalPanelArea(
                signalPanel1Transform,
                signalPanel2Transform,
                signalPanel3Transform,
                signalPanel4Transform))
            .AsSingle();

        // Prefab
        Container.BindFactory<int, IPlayer, PlayerFactory>()
            .FromSubContainerResolve()
            .ByNewPrefabInstaller<PlayerInstaller>(playerPrefab);

        Container.BindFactory<BulletData, Bullet, BulletFactory>()
            .FromComponentInNewPrefab(bulletPrefab)
            .AsTransient();

        Container.BindFactory<SignalPanel, DotSignalPanelFactory>()
            .FromComponentInNewPrefab(dotPanelPrefab)
            .AsTransient();

        Container.BindFactory<SignalPanel, DashSignalPanelFactory>()
            .FromComponentInNewPrefab(dashPanelPrefab)
            .AsTransient();

        // Container.BindFactory<SignalPanel, SignalPanelFactory>()
        //     .FromComponentInNewPrefab(dashPanelPrefab)
        //     .AsTransient();
        // MonoBehaviourを使用するManager類
        // TODO: FromComponentInHierarchy検討
        
        
        // Container.Bind<IMoveManager>()
        //     .To<MoveManager>()
        //     .FromComponentInHierarchy().AsSingle();
        Container.Bind<ICoroutineRunner>()
            .To<CoroutineRunner>()
            .FromComponentInHierarchy().AsSingle();
        
        // 純C#Managerなど
        Container.BindInterfacesTo<GameInitializer>().AsSingle();
        // Container.Bind<IBulletManager>().To<BulletManager>().AsSingle();
        Container.Bind<IPositionManager>().To<PositionManager>().AsSingle();
        Container.Bind<DamageEffectManager>().AsSingle();
        Container.Bind<IMatchManager>().To<MatchManager>().AsSingle();
        // Container.Bind<IKeyAssignManager>().To<KeyAssignManager>().AsSingle();
        Container.Bind<IMenuManager>().To<MenuManager>().AsSingle();

        SignalBusInstaller.Install(Container);
        Container.DeclareSignal<InputManagerSignal>();

        Container.BindFactory<int, TestObj, TestObj.Factory>()
            .FromSubContainerResolve()
            .ByNewPrefabInstaller<TestObjInstaller>(testPrefab);
    }
}
