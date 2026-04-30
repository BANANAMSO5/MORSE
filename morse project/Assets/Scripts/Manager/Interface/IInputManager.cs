using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputManager
{
    void Setenable(int Id);
    event Action<InputChar> OnFixChar;
    event Action OnDotSignal;
    event Action OnDashSignal;
    event Action OnEndSignal;
}
