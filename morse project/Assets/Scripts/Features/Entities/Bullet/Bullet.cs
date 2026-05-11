using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Bullet : MonoBehaviour, IBullet
{
    public int team;
    public float timer = 0f;
    public float moveTime = 1f;   // 1秒
    public float distance = 4.0f;

    Renderer rend;
    Vector3 startPos;
    Vector3 endPos;

    private int _playerId;
    private bool isMove = false;
    private BulletData _data;

    [Inject]
    public void Construct(BulletData data)
    {
        Debug.Log("ロケット生成, id:" + data.Id);
        _data = data;
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

                // 消える
                Destroy(gameObject);
            }
        }
    }

    public void Shot()
    {
        isMove = true;
        this.team = _data.Id;
        
        // 弾のみため
        //transform.localScale = new Vector3(direction, direction, transform.localScale.z);
        
        // 発射方向
        startPos = _data.Position + Vector3.right * 0.5f;
        endPos = startPos + Vector3.right * distance;
        Debug.Log(distance);
        Debug.Log(endPos);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Other object tag: " + other.gameObject.tag); 
        Debug.Log("Other object tag: " + other.CompareTag("Player"));
        // プレイヤーに衝突した場合
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Debug.Log("player.Id: " + _data.Id);
                if (player.PlayerId == _data.Id) { return; }
                // プレイヤーにダメージを与える
                health.TakeDamage(10);
                Destroy(gameObject);
            }
        }
    }
}
