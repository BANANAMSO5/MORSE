using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// InputManagerからの入力に対してどの行動や操作を行うか割り当てる
/// </summary>
public class KeyAssignManager : MonoBehaviour, IKeyAssignManager
{
    private IPlayer _player;
    private IInputManager _inputManager;
    private Action<IPlayer>[] _actions;

    [Inject]
    public void Construct(IInputManager inputManager)
    {
        _inputManager = inputManager;
    }

    public void KeyAssign(IPlayer player)
    {
        _player = player;
        _inputManager.Setenable(_player.PlayerId);
        _inputManager.OnFixChar += Handle;

        // スキル・行動などを登録
        // 順番や総数を変えないこと
        _actions = new Action<IPlayer>[]
        {
            null,                       // A
            null,                       // B
            null,                       // C
            null,                       // D
            null,                       // E
            null,                       // F
            null,                       // G
            null,                       // H
            _player.Behavior.ISignalAction.Execute,     // I
            null,                       // J
            null,                       // K
            null,                       // L
            _player.Behavior.MSignalAction.Execute,      // M
            null,                       // N
            null,                       // O
            null,                       // P
            null,                       // Q
            null,                       // R
            null,                       // S
            null,                       // T
            _player.Behavior.USignalAction.Execute,        // U
            null,                       // V
            null,                       // W
            null,                       // X
            null,                       // Y
            null,                       // Z
        };

        // // メニュー画面
        // _inputManager.RegisterPauseMenu(_menuManager.SwitchMenuMode);
    }


    public void Handle(InputChar type)
    {
        _actions[(int)type]?.Invoke(_player);
    }
}
