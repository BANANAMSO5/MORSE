using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject playerObject;

    public float time = 0f;
    public float duration = 60f;
    public float moveDistance = 3.0f;
    public float maxStretch = 3.0f;

    private bool isMove = false;
    Vector3 startPos;
    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name + " / " + GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            if (time < duration)
            {
                float t = time / duration;

                // 移動
                playerObject.transform.position = Vector3.Lerp(startPos, endPos, t);

                // 変形
                float stretch = Mathf.Lerp(1f, maxStretch, Mathf.Sin(t * Mathf.PI));
                playerObject.transform.localScale = new Vector3(stretch, 1f, 1f);

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

    public void MoveLeft()
    {
        isMove = true;
        startPos = playerObject.transform.position;
        endPos = startPos + Vector3.left * moveDistance; 
    }

    public void MoveRight()
    {
        isMove = true;
        startPos = playerObject.transform.position;
        endPos = startPos + Vector3.right * moveDistance; 
    }


    // 残骸
    IEnumerator Deformation(bool Dist)
    {
        float time = 0f;

        Vector3 startPos = playerObject.transform.position;
        Vector3 endPos = startPos + new Vector3(moveDistance * (Dist ? 1 : -1), 0, 0);

        while (time < duration)
        {
            float t = Mathf.Clamp01(time / duration); // ← 共通の時間

            // 移動（最初から最後まで同じ時間）
            playerObject.transform.position = Vector3.Lerp(startPos, endPos, t);

            // 変形（同じtを使って前半伸びて後半戻る）
            float stretch = Mathf.Lerp(1f, maxStretch, Mathf.Sin(t * Mathf.PI));

            playerObject.transform.localScale = new Vector3(stretch, 1f, 1f);

            time += Time.deltaTime / duration;

            Debug.Log(t);
            yield return null;
        }

        // 最終補正
        playerObject.transform.position = endPos;
        playerObject.transform.localScale = Vector3.one;
    }
}
