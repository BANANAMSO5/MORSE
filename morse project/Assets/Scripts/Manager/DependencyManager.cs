using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各クラスの依存関係、インスタンスの管理をする
/// </summary>
public class DependencyManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject playerObject; 
    public GameObject playerBot;
    public MoveManager moveManager;
    public BulletManager bulletManager;
    public PositionManager positionManager;
    public TextUIManager textUIManager;
    public DamageEffectManager damageEffectManager;
    // public MatchManager matchManager;


    Player player1;
    Player player2;

    // 一番最初に実行
    void Awake()
    {
        player1 = playerObject.GetComponent<Player>();
        player2 = playerBot.GetComponent<Player>();

        bulletManager.player = player1;


        damageEffectManager.mainCamera = mainCamera;
        // TODO:いったん敵だけ
        damageEffectManager.playerObject = playerBot;

    }
}
