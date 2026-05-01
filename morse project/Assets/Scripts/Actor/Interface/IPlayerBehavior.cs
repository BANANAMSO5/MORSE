using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBehavior
{
    IMoveManager MoveManager { get; }
    IBulletManager BulletManager { get; }
}
