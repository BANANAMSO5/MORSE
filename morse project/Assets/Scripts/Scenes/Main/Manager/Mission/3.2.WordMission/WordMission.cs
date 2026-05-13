using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordMission : MonoBehaviour, IWordMission
{
    private IInputManager _inputManager;
    private IFactorChecker _wordChecker;

    [Inject]
    public void Construct(
        IInputManager inputManager, 
        IFactorChecker wordChecker
    )
    {
        _inputManager = inputManager;
        _inputManager.OnFixChar += FixCharHandle;
        _wordChecker = wordChecker;
    }

    // 
    public void FixCharHandle(InputChar inputChar)
    {
        _wordChecker.Check(inputChar);
    }
}
