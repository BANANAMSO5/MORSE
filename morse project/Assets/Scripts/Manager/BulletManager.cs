using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class BulletManager : MonoBehaviour, IBulletManager
{
    private int _playerId;
    private BulletFactory _factory;

    [Inject]
    public void Construct(int playerId, BulletFactory factory)
    {
        _playerId = playerId;
        _factory = factory;
    }

    public void Shot()
    {
        IBullet bullet = _factory.Create(10);
        //TODO: 生成した瞬間時点で、、にしたい（Shotいらない）
        // bullet.Shot();
    }
}
