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

    [Inject]
    DiContainer container;

    // Start is called before the first frame update
    void Start()
    {
        Id = 1;
        // // とりあえずPlayer1
        // InputManagerのIdなどの固定値に紐づけるため、基本的に1,2としたい
        IPlayer player1 =_factory.Create(Id);
        IPlayer player2 = _factory.Create(2);

        IKeyAssignManager keyManager1 = container.ResolveId<IKeyAssignManager>(Id);
        IKeyAssignManager keyManager2 = container.ResolveId<IKeyAssignManager>(2);
        keyManager1.KeyAssign(player1);
        keyManager2.KeyAssign(player2);

        InputRouteManager routeManager1 = container.ResolveId<InputRouteManager>(Id);
        InputRouteManager routeManager2 = container.ResolveId<InputRouteManager>(2);
        routeManager1.InputRoute(player1);
        routeManager2.InputRoute(player2);

        player2.SetPosition(new Vector3(6,0,0));
    }
}
