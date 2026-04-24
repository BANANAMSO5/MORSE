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
    public InputManager inputManager;
    public MoveManager moveManager;
    public BulletManager bulletManager;
    public PositionManager positionManager;
    public TextUIManager textUIManager;
    public DamageEffectManager damageEffectManager;
    public MatchManager matchManager;


    Player player1;
    Player player2;

    // 一番最初に実行
    void Awake()
    {
        player1 = playerObject.GetComponent<Player>();
        player2 = playerBot.GetComponent<Player>();

        moveManager.playerObject = playerObject;
        bulletManager.player = player1;

        inputManager.playerObject = playerObject;
        inputManager.mm = moveManager;
        inputManager.bm = bulletManager;
        inputManager.textUIManager = textUIManager;

        positionManager.player1Object = playerObject;
        positionManager.player2Object = playerBot;

        damageEffectManager.mainCamera = mainCamera;
        // TODO:いったん敵だけ
        damageEffectManager.playerObject = playerBot;

        matchManager.player1 = player1;
        matchManager.player2 = player2;
    }
}
