using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class KeyAssignManager : IKeyAssignManager
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
    }

    public void KeyAssign()
    {
        _inputManager.RegisterAction("I", _moveManager.MoveRight);
        _inputManager.RegisterAction("M", _moveManager.MoveLeft);
        _inputManager.RegisterAction("U", _bulletManager.Shot);

        _inputManager.RegisterChangeTextAction(_textUIManager.ChangeText);

        _inputManager.RegisterPauseMenu(_menuManager.SwitchMenuMode);
    }
}
