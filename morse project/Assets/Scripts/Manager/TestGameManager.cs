using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security;
using UnityEngine;
using Zenject;
using Vector3 = UnityEngine.Vector3;

public class TestGameManager : MonoBehaviour
{
    public static int Id;


    [Inject]
    PlayerFactory _factory;

    // Start is called before the first frame update
    void Start()
    {
        Id = 1;
        // // とりあえずPlayer1
        IPlayer player1 =_factory.Create(Id);
        IPlayer player2 = _factory.Create(2);

        player2.SetPosition(new Vector3(3,0,0));
    }
}
