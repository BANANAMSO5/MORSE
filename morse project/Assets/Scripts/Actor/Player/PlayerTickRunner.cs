using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerTickRunner : ITickable, IPlayerTickRunner
{
    readonly Queue<ITickAction> _queue = new();

    const int MaxBuffered = 2;

    ITickAction _current;

    public void Add(ITickAction action)
    {
        if (_queue.Count >= MaxBuffered)
        {
            Debug.Log("MoveSystem: queue full");
            return;
        }

        _queue.Enqueue(action);

        if (_current == null)
            _current = _queue.Dequeue();
    }

    public void Tick()
    {
        if (_current == null)
            return;

        _current.Tick();

        if (!_current.IsActive)
        {
            _current = _queue.Count > 0 ? _queue.Dequeue() : null;
        }
    }
}
