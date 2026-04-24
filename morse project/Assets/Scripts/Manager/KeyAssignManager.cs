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

    [Inject]
    public void Construct(
        IInputManager inputManager,
        IMoveManager moveManager,
        IBulletManager bulletManager)
    {
        _inputManager = inputManager;
        _moveManager = moveManager;
        _bulletManager = bulletManager;

        Debug.Log("KeyAssignManager init");
    }

    public void KeyAssign()
    {
        _inputManager.Register("I", _moveManager.MoveRight);
        _inputManager.Register("M", _moveManager.MoveLeft);
        _inputManager.Register("U", _bulletManager.Shot);
    }
}
