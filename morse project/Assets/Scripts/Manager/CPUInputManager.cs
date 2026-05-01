using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUInputManager : MonoBehaviour, IInputManager
{
    public event Action<InputChar> OnFixChar;
    public event Action OnDotSignal;
    public event Action OnDashSignal;
    public event Action OnEndSignal;

    public void Setenable(int id)
    {
    }
}
