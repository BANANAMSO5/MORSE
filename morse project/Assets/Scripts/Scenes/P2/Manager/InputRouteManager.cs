using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputRouteManager : MonoBehaviour
{
    private IInputManager _inputManager;

    [Inject]
    public void Construct(IInputManager inputManager)
    {
        _inputManager = inputManager;
    }

    public void InputRoute(IPlayer player)
    {
        bool _isLocalPlayer = player.PlayerId == TestGameManager.Id;
        _inputManager.SetActive(_isLocalPlayer);
    }
}
