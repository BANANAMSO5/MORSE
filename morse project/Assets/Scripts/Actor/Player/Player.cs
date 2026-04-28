using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IPlayer
{
    public int direction = 1;

    public event Action<Vector3> OnPositionChanged;

    public int PlayerId;


    [Inject]
    public void Construct(int playerId)
    {
        PlayerId = playerId;
    }
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
