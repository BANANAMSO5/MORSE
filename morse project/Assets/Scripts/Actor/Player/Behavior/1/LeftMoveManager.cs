using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMoveManager : MonoBehaviour, IMSignalAction
{
    public float time = 0f;
    public float duration = 60f;
    public float moveDistance = 3.0f;
    public float maxStretch = 3.0f;

    private bool isMove = false;
    Vector3 startPos;
    Vector3 endPos;

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (time < duration)
            {
                float t = time / duration;

                // 移動
                transform.position = Vector3.Lerp(startPos, endPos, t);

                // 変形
                float stretch = Mathf.Lerp(1f, maxStretch, Mathf.Sin(t * Mathf.PI));
                transform.localScale = new Vector3(stretch, 1f, 1f);

                time += 1;
                
                // Debug.Log("duration:" + duration);
                // Debug.Log("t:" + t);
                // Debug.Log("time:" + time);
            }
            else
            {
                isMove = false;
                time = 0;

                // Debug.Log("isMove:" + isMove);
                // Debug.Log("startPos:" + startPos);
                // Debug.Log("endPos:" + endPos);

                return;
            }
        }
    }

    public void Execute()
    {
        isMove = true;
        startPos = transform.position;
        endPos = startPos + Vector3.left * moveDistance; 
    }
}
