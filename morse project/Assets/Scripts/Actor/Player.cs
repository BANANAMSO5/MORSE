using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
    public Team team;
    public int direction = 1;

    public TextMeshPro hpText;

    public event Action<Vector3> OnPositionChanged;

    private IInputManager _inputManager;
    private IMoveManager _moveManager;
    private IBulletManager _bulletManager;
    private ITextUIManager _textUIManager;


    [Inject]
    public void Construct(
        IInputManager inputManager,
        IMoveManager moveManager,
        IBulletManager bulletManager,
        ITextUIManager textUIManager)
    {
        _inputManager = inputManager;
        _moveManager = moveManager;
        _bulletManager = bulletManager;
        _textUIManager = textUIManager;

        KeyAssign();
    }
    
    private void KeyAssign()
    {
        // スキル・行動などを登録
        _inputManager.RegisterAction("I", _moveManager.MoveRight);
        _inputManager.RegisterAction("M", _moveManager.MoveLeft);
        _inputManager.RegisterAction("U", _bulletManager.Shot);

        // 入力された文字を表示
        _inputManager.RegisterChangeTextAction(_textUIManager.ChangeText);
    }
}
