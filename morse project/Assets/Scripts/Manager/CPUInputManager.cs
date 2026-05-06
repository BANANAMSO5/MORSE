using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CPUInputManager : MonoBehaviour, IInputManager
{
    public event Action<InputChar> OnFixChar;
    public event Action OnDotSignal;
    public event Action OnDashSignal;
    public event Action OnEndSignal;

    private Action[] _actions;
    private float[] _intervals = { 
        0.3f, 0.3f, 0.3f, 0.5f, 
        0.3f, 0.3f, 0.3f, 0.5f 
    };
    private int _index = 0;
    private float _timer = 0f;

    [Inject]
    public void Construct()
    {
        enabled = false;
    }
    
    public void SetActive(bool value)
    {
        enabled = true;
    }

    void Start()
    {
        _actions = new Action[]
        {
            DotSignal,
            DotSignal,
            EndSignal,
            ActionI,

            DashSignal,
            DashSignal,
            EndSignal,
            ActionM,
        };
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _intervals[_index])
        {
            _timer -= _intervals[_index];

            _actions[_index]?.Invoke();

            _index = (_index + 1) % _actions.Length;
        }
    }

    private void DotSignal() => OnDotSignal?.Invoke();
    private void DashSignal() => OnDashSignal?.Invoke();
    private void EndSignal() => OnEndSignal.Invoke();
    private void ActionI() => OnFixChar?.Invoke(InputChar.I);
    private void ActionM() => OnFixChar?.Invoke(InputChar.M);
}
