using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestObjB : MonoBehaviour
{
    private int _id;

    [Inject]
    public void Construct(int id)
    {
        _id = id;
        Debug.Log("TestObjB:" + _id);
    }
}
