using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Bullet : MonoBehaviour
{
    public int Id;
    public float timer = 0f;
    public float moveTime = 1f;   // 1秒
    public float distance = 4.0f;
    public class Factory : PlaceholderFactory<Bullet> { }

    Renderer rend;
    Vector3 startPos;
    Vector3 endPos;

    private bool isMove = false;

    [Inject]
    public void Construct()
    {
        Debug.Log("生成");
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

    public void Shot(int id, int direction)
    {
        isMove = true;
        this.Id = id;
        
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
            Player player = other.GetComponent<Player>();  // プレイヤーのPlayerスクリプトを取得
            if (player != null)
            {
                Debug.Log("player.Id: " + player.Id + "this.Id: " + this.Id);  // タグを確認
                if (player.Id == this.Id) { return; }
                player.TakeDamage(10);  // プレイヤーにダメージを与える
                Destroy(gameObject);
            }
        }
    }
}
