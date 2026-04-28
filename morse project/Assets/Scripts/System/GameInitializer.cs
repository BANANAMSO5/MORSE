using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInitializer : IInitializable
{

    [Inject]
    public GameInitializer()
    {
    }

    public void Initialize()
    {
    }
}
