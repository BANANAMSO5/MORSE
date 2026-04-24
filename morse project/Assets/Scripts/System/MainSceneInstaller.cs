using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MainSceneInstaller : MonoInstaller
{
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private Bullet bullet;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Canvas pausePanel;
    
    public override void InstallBindings()
    {
        // ゲーム内オブジェクト
        Container.Bind<Player>()
            .WithId("player1")
            .FromInstance(player1);
        Container.Bind<Player>()
            .WithId("player2")
            .FromInstance(player2);
        Container.BindFactory<Bullet, Bullet.Factory>()
            .FromComponentInNewPrefab(bullet)
            .AsTransient();
        Container.Bind<CanvasGroup>()
            .FromInstance(canvasGroup);
        Container.Bind<TextMeshProUGUI>()
            .FromInstance(text);
        Container.Bind<Canvas>()
            .FromInstance(pausePanel);
        
        // MonoBehaviourを使用するManager類
        // TODO: FromComponentInHierarchy検討
        Container.Bind<IInputManager>()
            .To<InputManager>()
            .FromComponentInHierarchy().AsSingle();
        Container.Bind<IMoveManager>()
            .To<MoveManager>()
            .FromComponentInHierarchy().AsSingle();
        Container.Bind<ICoroutineRunner>()
            .To<CoroutineRunner>()
            .FromComponentInHierarchy().AsSingle();
        
        // 純C#Managerなど
        Container.BindInterfacesTo<GameInitializer>().AsSingle();
        Container.Bind<IBulletManager>().To<BulletManager>().AsSingle();
        Container.Bind<IPositionManager>().To<PositionManager>().AsSingle();
        Container.Bind<ITextUIManager>().To<TextUIManager>().AsSingle();
        Container.Bind<DamageEffectManager>().AsSingle();
        Container.Bind<MatchManager>().AsSingle();
        Container.Bind<IKeyAssignManager>().To<KeyAssignManager>().AsSingle();
        Container.Bind<IMenuManager>().To<MenuManager>().AsSingle();
    }
}
