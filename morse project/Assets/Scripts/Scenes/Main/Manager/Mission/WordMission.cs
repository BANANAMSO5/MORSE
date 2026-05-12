using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WordMission : MonoBehaviour, IWordMission
{
    private IInputManager _inputManager;
    private IWordChecker _wordChecker;

    [Inject]
    public void Construct(
        IInputManager inputManager, 
        IWordChecker wordChecker
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
