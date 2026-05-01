using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    int PlayerId { get; }
    IPlayerBehavior Behavior { get; }
    void SetPosition(Vector3 position);
}
