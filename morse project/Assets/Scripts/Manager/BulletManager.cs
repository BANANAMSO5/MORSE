using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class BulletManager : IBulletManager
{
    private Bullet.Factory _factory;
    private Player _player;

    // [Inject]
    public void Construct(Bullet.Factory factory, [Inject(Id = "player1")]Player player)
    {
        _factory = factory;
        _player = player;
    }

    public void Shot()
    {
        Bullet bullet = _factory.Create();
        //bullet.transform.position = _player.gameObject.transform.position;
        bullet.Shot(_player.team, _player.direction);
    }
}
