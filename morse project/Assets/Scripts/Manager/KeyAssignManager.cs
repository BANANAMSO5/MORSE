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
    private ITextUIManager _textUIManager;
    private IMenuManager _menuManager;
    private Action[] _actions;

    [Inject]
    public void Construct(
        IInputManager inputManager,
        IMoveManager moveManager,
        IBulletManager bulletManager
        // ITextUIManager textUIManager
        // IMenuManager menuManager
    )
    {
        _inputManager = inputManager;
        _moveManager = moveManager;
        _bulletManager = bulletManager;
        // _textUIManager = textUIManager;
        // _menuManager = menuManager;

        KeyAssign();
    }

    public void KeyAssign()
    {
        _inputManager.OnSignal += Handle;

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
            _moveManager.MoveRight,     // I
            null,                       // J
            null,                       // K
            null,                       // L
            _moveManager.MoveLeft,      // M
            null,                       // N
            null,                       // O
            null,                       // P
            null,                       // Q
            null,                       // R
            null,                       // S
            null,                       // T
            _bulletManager.Shot,        // U
            null,                       // V
            null,                       // W
            null,                       // X
            null,                       // Y
            null,                       // Z
        };

        // // 入力された文字を表示
        // _inputManager.RegisterChangeTextAction(_textUIManager.ChangeText);

        // // メニュー画面
        // _inputManager.RegisterPauseMenu(_menuManager.SwitchMenuMode);
    }


    public void Handle(InputSignal type)
    {
        _actions[(int)type]?.Invoke();
    }
}
