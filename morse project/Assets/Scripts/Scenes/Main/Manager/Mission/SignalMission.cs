using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalMission : MonoBehaviour, ISignalMission
{
    private IInputManager _inputManager;
    private IMissionTracker _missionTracker;

    [Inject]
    public void Construct(
        IInputManager inputManager, 
        IMissionTracker missionTracker
    )
    {
        _inputManager = inputManager;
        _inputManager.OnFixChar += FixCharHandle;
        _missionTracker = missionTracker;
    }

    // 
    public void FixCharHandle(InputChar inputChar)
    {
        _missionTracker.AddProgress("mission_a");
    }
}
