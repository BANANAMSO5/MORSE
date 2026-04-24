using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MatchManager : MonoBehaviour
{
    private Player _player1;
    private Player _player2;

    [Inject]
    public void Construct([Inject(Id = "player1")]Player player1, [Inject(Id = "player2")]Player player2)
    {
        _player1 = player1;
        _player2 = player2;
        _player1.OnDeath += DecisionMatch;
        _player2.OnDeath += DecisionMatch;
    }

    public void DecisionMatch(Player deadPlayer)
    {
        Player winner = (deadPlayer == _player1) ? _player2 : _player1;
        Debug.Log($"勝者: {winner}!");
        //TODO:リザルト、リトライ画面
    }
}
