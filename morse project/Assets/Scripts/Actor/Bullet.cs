using System.Collections;
using System.Collections.Generic;
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

    public Bullet(int playerId)
    {
        Debug.Log("ロケット生成, id:" + playerId);
        _playerId = playerId;
    }

    // Start is called before the first frame update
    void Start()
    {
        // isMove = true;
        // startPos = transform.position + Vector3.right * 0.5f;
        // endPos = startPos + Vector3.right * distance;
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
        this.team = _playerId;
        
        // 弾のみため
        //transform.localScale = new Vector3(direction, direction, transform.localScale.z);
        
        // 発射方向
        startPos = transform.position + Vector3.right * 0.5f;
        endPos = startPos + Vector3.right * distance;
        Debug.Log(distance);
        Debug.Log(endPos);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Other object tag: " + other.gameObject.tag); 
        Debug.Log("Other object tag: " + other.CompareTag("Player"));  // タグを確認
        // プレイヤーに衝突した場合
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            PlayerHealth health = other.GetComponent<PlayerHealth>();  // プレイヤーのPlayerスクリプトを取得
            if (player != null)
            {
                Debug.Log("player.Id: " + player.team + "this.Id: " + this.team);  // タグを確認
                if (player.team == this.team) { return; }
                health.TakeDamage(10);  // プレイヤーにダメージを与える
                Destroy(gameObject);
            }
        }
    }
}
