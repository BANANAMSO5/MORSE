using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 各クラスの依存関係、インスタンスの管理をする
/// </summary>
public class DependencyManager : MonoBehaviour
{
    public GameObject playerObject; 
    public GameObject playerBot;
    public InputManager inputManager;
    public MoveManager moveManager;
    public BulletManager bulletManager;
    public PositionManager positionManager;


    void Start()
    {
        moveManager.playerObject = playerObject;
        bulletManager.playerObject = playerObject;

        inputManager.playerObject = playerObject;
        inputManager.mm = moveManager;
        inputManager.bm = bulletManager;

        positionManager.player1Object = playerObject;
        positionManager.player2Object = playerBot;
    }
}
