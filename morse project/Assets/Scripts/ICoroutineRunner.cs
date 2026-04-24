using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutineRunner
{
    Coroutine StartProcess(IEnumerator routine);
    void StopProcess(Coroutine routine);
}
