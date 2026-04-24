using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
{
    public Coroutine StartProcess(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public void StopProcess(Coroutine routine)
    {
        StopCoroutine(routine);
    }
}
