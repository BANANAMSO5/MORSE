using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
    public int direction = 1;

    public int PlayerId { get; set; }
    public IPlayerBehavior Behavior { get; set; }


    [Inject]
    public void Construct(int playerId, IPlayerBehavior behavior)
    {
        PlayerId = playerId;
        Behavior = behavior;
    }
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
