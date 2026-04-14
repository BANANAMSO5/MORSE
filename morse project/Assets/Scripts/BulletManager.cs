using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Player player;
    public float moveTime = 1f;   // 1秒
    public float distance = 4.0f;
    public float timer = 0f;

    Renderer rend;
    Vector3 startPos;
    Vector3 endPos;

    private bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false; // 最初は非表示
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            timer += Time.deltaTime;

            float t = timer / moveTime;

            transform.position = Vector3.Lerp(startPos, endPos, t);

            // 終了処理
            if (t >= 1f)
            {
                transform.position = endPos;

                isMove = false;
                timer = 0f;

                rend.enabled = false; // 消える
            }
        }
    }

    public void Shot()
    {
        isMove = true;
        startPos = player.Position + Vector3.right * 0.5f;
        endPos = startPos + Vector3.right * distance;

        rend.enabled = true; // 出現
    }
}
