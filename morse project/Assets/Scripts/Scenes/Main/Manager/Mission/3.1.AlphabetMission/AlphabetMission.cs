using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AlphabetMission : MonoBehaviour, IAlphabetMission
{
    private IInputManager _inputManager;
    private IFactorChecker _alphabetChecker;

    [Inject]
    public void Construct(
        IInputManager inputManager, 
        IFactorChecker alphabetChecker
    )
    {
        _inputManager = inputManager;
        _inputManager.OnFixChar += FixCharHandle;
        _alphabetChecker = alphabetChecker;
    }

    // 
    public void FixCharHandle(InputChar inputChar)
    {
        _alphabetChecker.Check(inputChar);
    }
}
