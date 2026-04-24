using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputManager
{
    void RegisterAction(string signal, Action action);
    void RegisterChangeTextAction(Action<string> action);
    void RegisterPauseMenu(Action action);
}
