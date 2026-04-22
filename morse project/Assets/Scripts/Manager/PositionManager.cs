using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1v1のときこれを使ってみる
/// </summary>
public class PositionManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject player1Object;
    [HideInInspector]
    public GameObject player2Object;

    Player player1;
    Player player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = player1Object.GetComponent<Player>();
        player2 = player2Object.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player1Object.transform.position.x < player2Object.transform.position.x)
        {
            player1.direction = 1;
            player2.direction = -1;
        }
        else if (player1Object.transform.position.x > player2Object.transform.position.x)
        {
            player1.direction = -1;
            player2.direction = 1;
        }
    }
}
