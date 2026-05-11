using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalMission : MonoBehaviour, ISignalMission
{
     [SerializeField]
    private MissionDefinition[] definitions;
    private IInputManager _inputManager;
    private ISignalMissionTracker _missionTracker;

    [Inject]
    public void Construct(
        IInputManager inputManager, 
        ISignalMissionTracker missionTracker
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
