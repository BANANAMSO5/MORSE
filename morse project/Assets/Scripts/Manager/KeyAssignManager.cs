using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyAssignManager : MonoBehaviour, IKeyAssignManager
{
    private IInputManager _inputManager;
    private IMoveManager _moveManager;
    private IBulletManager _bulletManager;
    private ITextUIManager _textUIManager;
    private IMenuManager _menuManager;

    [Inject]
    public void Construct(
        IInputManager inputManager,
        IMoveManager moveManager,
        IBulletManager bulletManager,
        ITextUIManager textUIManager,
        IMenuManager menuManager)
    {
        _inputManager = inputManager;
        _moveManager = moveManager;
        _bulletManager = bulletManager;
        _textUIManager = textUIManager;
        _menuManager = menuManager;

        KeyAssign();
    }

    public void KeyAssign()
    {
        Debug.Log(":" + _inputManager);
        // スキル・行動などを登録
        _inputManager.RegisterAction("I", _moveManager.MoveRight);
        _inputManager.RegisterAction("M", _moveManager.MoveLeft);
        _inputManager.RegisterAction("U", _bulletManager.Shot);

        // // 入力された文字を表示
        // _inputManager.RegisterChangeTextAction(_textUIManager.ChangeText);

        // // メニュー画面
        // _inputManager.RegisterPauseMenu(_menuManager.SwitchMenuMode);
    }
}
