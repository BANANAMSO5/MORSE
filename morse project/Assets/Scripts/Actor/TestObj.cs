using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TestObj : MonoBehaviour
{
    private int _id;

    [Inject]
    public void Construct(int id)
    {
        _id = id;
        Debug.Log("TestObj:" + _id);
    }

    public class Factory : PlaceholderFactory<int, TestObj>
    {
    }
}
