using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectService
{
    void DestroyObject(GameObject obj);
    Coroutine StartProcess(IEnumerator routine);
    void StopProcess(Coroutine routine);
}
