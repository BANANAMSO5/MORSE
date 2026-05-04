using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RightMoveManager : IISignalAction, ITickAction
{
    public float time = 0f;
    public float duration = 60f;
    public float moveDistance = 3.0f;
    public float maxStretch = 3.0f;
    public bool IsActive => time < duration;

    private Transform _target;
    private IPlayerTickRunner _runner;
    Vector3 startPos;
    Vector3 endPos;

    [Inject]
    public void Construct(IPlayerTickRunner runner)
    {
        _runner = runner;
    }

    public void Tick()
    {
        float t = time / duration;

        // 移動
        _target.position = Vector3.Lerp(startPos, endPos, t);

        // 変形
        float stretch = Mathf.Lerp(1f, maxStretch, Mathf.Sin(t * Mathf.PI));
        _target.localScale = new Vector3(stretch, 1f, 1f);

        time += 1;
    }

    public void Execute(IPlayer player)
    {
        
        time = 0;
        _target = player.Transform;
        startPos = _target.position;
        endPos = startPos + Vector3.right * moveDistance; 

        _runner.Add(this);
    }
}
