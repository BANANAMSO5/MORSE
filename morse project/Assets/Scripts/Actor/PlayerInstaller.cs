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

        Container.Bind<IInputManager>()
            .To<InputManager>()
            .FromComponentOnRoot().AsSingle();

        Container.Bind<IMoveManager>()
            .To<MoveManager>()
            .FromComponentOnRoot().AsSingle();

        Container.Bind<PlayerHealth>()
            .FromComponentOnRoot().AsSingle();
        
        
        //Container.BindInterfacesAndSelfTo<PlayerInput>().AsSingle();
    }
}
