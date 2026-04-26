using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestGameManager : MonoBehaviour
{
    public static TestGameManager Instance { get; private set; }
    public static int Id;


    [Inject]
    PlayerFactory _factory;

    // Start is called before the first frame update
    void Start()
    {

        // _testFactory.Create(1);
        // _testFactory.Create(2);

        Id = 1;
        // // とりあえずPlayer1
        _factory.Create(Id);
        // _factory.Create(2);
    }
}
