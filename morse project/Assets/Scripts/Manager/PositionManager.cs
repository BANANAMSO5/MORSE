using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// 1v1のときこれを使ってみる
/// 今意味ない
/// </summary>
public class PositionManager : IPositionManager
{
    private Player _player1;
    private Player _player2;
    private Vector3 _position1;
    private Vector3 _position2;

    [Inject]
    public void Construct([Inject(Id = "player1")]Player player1, [Inject(Id = "player2")]Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _player1.OnPositionChanged += pos =>
        {
            _position1 = pos;
            CheckPosition();
        };

        _player2.OnPositionChanged += pos =>
        {
            _position2 = pos;
            CheckPosition();
        };
    }

    // Update is called once per frame
    public void CheckPosition()
    {
        if (_position1.x < _position2.x)
        {
            _player1.direction = 1;
            _player2.direction = -1;
        }
        else if (_position1.x > _position2.x)
        {
            _player1.direction = -1;
            _player2.direction = 1;
        }
    }
}
