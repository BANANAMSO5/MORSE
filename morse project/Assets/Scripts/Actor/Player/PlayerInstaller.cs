using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : Installer<int, PlayerInstaller>
{
    private int _playerId;

    public PlayerInstaller(int playerId)
    {
        _playerId = playerId;
    }

    public override void InstallBindings()
    {
        Debug.Log($"Binding ID: {_playerId}");

        Container.BindInstance(_playerId);
        
        Container.Bind<IPlayer>()
            .To<Player>()
            .FromComponentOnRoot().AsSingle();

        // Container.Bind<IInputManager>()
        //     .To<InputManager>()
        //     .FromComponentOnRoot().AsSingle();

        // Container.Bind<IKeyAssignManager>()
        //     .To<KeyAssignManager>()
        //     .FromComponentOnRoot().AsSingle();

        Container.BindInterfacesTo<RightMoveManager>().AsSingle();

        Container.BindInterfacesTo<LeftMoveManager>().AsSingle();

        Container.Bind<IUSignalAction>()
            .To<BulletManager>().AsSingle();

        Container.Bind<PlayerHealth>()
            .FromComponentOnRoot().AsSingle();

        Container.Bind<IPlayerBehavior>()
            .To<PlayerBehavior>()
            .FromComponentOnRoot().AsSingle();
    }
}
