using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SignalUIManager : MonoBehaviour
{
    private SignalBus _signalBus;
    private string[] _actionTexts;

    // [Inject]
    // public void Construct(SignalBus signalBus)
    // {
    //     _signalBus = signalBus;
    //     _signalBus.Subscribe<InputManagerSignal>(OnGenerate);
    // }

    public void OnGenerate(InputManagerSignal signal)
    {
        signal.Instance.OnFixSignal += Handle;
    }

    public void Handle(InputSignal signal)
    {
        
    }
}
