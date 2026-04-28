using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

/// <summary>
/// 遠距離系の技を管理するクラス
/// </summary>
public class BulletManager : MonoBehaviour, IBulletManager
{
    // Bulletの共通データ
    private BulletData _data;
    private BulletFactory _factory;

    [Inject]
    public void Construct(int playerId, BulletFactory factory)
    {
        _data.Id = playerId;
        _factory = factory;
    }

    // TODO:あとでメソッド名かえる
    public void Shot()
    {
        _data.Position = transform.position;
        Bullet bullet = _factory.Create(_data);
        // TODO: Shot()なしでいきたい
        bullet.Shot();
    }
}
