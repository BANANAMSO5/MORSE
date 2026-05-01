using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBehavior : MonoBehaviour, IPlayerBehavior
{
    public IMoveManager MoveManager { get; set; }
    public IBulletManager BulletManager { get; set; }

    [Inject]
    public void Construct(
        IMoveManager moveManager,
        IBulletManager bulletManager
    )
    {
        MoveManager = moveManager;
        BulletManager = bulletManager;
    }
}
