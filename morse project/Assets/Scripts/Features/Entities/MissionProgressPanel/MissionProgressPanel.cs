using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissionProgressPanel : MonoBehaviour, IPanel
{
    [Inject]
    public void Construct(float value)
    {
        Debug.Log("value:" + value);
    }
}
