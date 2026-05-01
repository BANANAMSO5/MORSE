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
        // InputManagerのIdなどの固定値に紐づけるため、基本的に1,2としたい
        IPlayer player1 =_factory.Create(Id);
        IPlayer player2 = _factory.Create(99);

        player2.SetPosition(new Vector3(6,0,0));
    }
}
