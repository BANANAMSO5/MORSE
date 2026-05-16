using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInitializer : IInitializable
{
    private IAutoSaveManager _autoSaveManager;
    private IInitLoadManager _initLoadManager;

    [Inject]
    public void Construct(
        IAutoSaveManager autoSaveManager,
        IInitLoadManager initLoadManager
    )
    {
        _initLoadManager = initLoadManager;
        _autoSaveManager = autoSaveManager;
        Debug.Log("auto save start");
    }

    public void Initialize()
    {
    }
}
