using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RightMoveManager : ITickable, IISignalAction
{
    public float time = 0f;
    public float duration = 60f;
    public float moveDistance = 3.0f;
    public float maxStretch = 3.0f;

    private Transform _target;
    private bool _isMove = false;
    Vector3 startPos;
    Vector3 endPos;

    // Update is called once per frame
    public void Tick()
    {
        if (_isMove)
        {
            if (time < duration)
            {
                float t = time / duration;

                // 移動
                _target.position = Vector3.Lerp(startPos, endPos, t);

                // 変形
                float stretch = Mathf.Lerp(1f, maxStretch, Mathf.Sin(t * Mathf.PI));
                _target.localScale = new Vector3(stretch, 1f, 1f);

                time += 1;
            }
            else
            {
                _isMove = false;
                time = 0;

                return;
            }
        }
    }

    public void Execute(IPlayer player)
    {
        _target = player.Transform;
        _isMove = true;
        startPos = _target.position;
        endPos = startPos + Vector3.right * moveDistance; 
    }
}
