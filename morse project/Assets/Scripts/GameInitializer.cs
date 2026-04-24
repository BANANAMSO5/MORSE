using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInitializer : IInitializable
{
    IKeyAssignManager _keyAssignManager;

    [Inject]
    public GameInitializer(IKeyAssignManager keyAssignManager)
    {
        Debug.Log("GameInitializer init");
        _keyAssignManager = keyAssignManager;
    }

    public void Initialize()
    {
        _keyAssignManager.KeyAssign();
    }
}
