using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITickAction
{
    bool IsActive { get; }
    void Tick();
}
