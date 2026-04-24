using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [HideInInspector]
    public Player player1;
    [HideInInspector]
    public Player player2;

    void Start()
    {
        player1.OnDeath += DecisionMatch;
        player2.OnDeath += DecisionMatch;
    }

    void OnDestroy()
    {
    }

    public void DecisionMatch(Player deadPlayer)
    {
        Player winner = (deadPlayer == player1) ? player2 : player1;
        Debug.Log($"勝者: {winner}!");
        //TODO:リザルト、リトライ画面
    }
}
