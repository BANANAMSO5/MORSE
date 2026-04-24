using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class BulletManager : MonoBehaviour, IBulletManager
{
    private Bullet.Factory _factory;

    [HideInInspector]
    public Player player;

    [Inject]
    public void Construct(Bullet.Factory factory)
    {
        _factory = factory;
    }

    public void Shot()
    {
        Bullet bullet = _factory.Create();
        bullet.transform.position = player.gameObject.transform.position;
        bullet.Shot(player.Id, player.direction);
    }
}
