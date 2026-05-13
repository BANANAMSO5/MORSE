using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectService : MonoBehaviour, IObjectService
{
    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    public Coroutine StartProcess(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public void StopProcess(Coroutine routine)
    {
        StopCoroutine(routine);
    }
}
