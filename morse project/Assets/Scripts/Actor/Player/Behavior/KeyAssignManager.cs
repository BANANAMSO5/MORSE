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
    private IInputManager _inputManager;
    private IMoveManager _moveManager;
    private IBulletManager _bulletManager;
    private IMenuManager _menuManager;
    private Action[] _actions;

    [Inject]
    public void Construct(IInputManager inputManager)
    {
        _inputManager = inputManager;
        // _textUIManager = textUIManager;
        // _menuManager = menuManager;

    }

    public void KeyAssign(IPlayer player)
    {
        _inputManager.Setenable(player.PlayerId);
        _inputManager.OnFixChar += Handle;

        // スキル・行動などを登録
        // 順番や総数を変えないこと
        _actions = new Action[]
        {
            null,                       // A
            null,                       // B
            null,                       // C
            null,                       // D
            null,                       // E
            null,                       // F
            null,                       // G
            null,                       // H
            player.Behavior.MoveManager.MoveRight,     // I
            null,                       // J
            null,                       // K
            null,                       // L
            player.Behavior.MoveManager.MoveLeft,      // M
            null,                       // N
            null,                       // O
            null,                       // P
            null,                       // Q
            null,                       // R
            null,                       // S
            null,                       // T
            player.Behavior.BulletManager.Shot,        // U
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
        _actions[(int)type]?.Invoke();
    }
}
