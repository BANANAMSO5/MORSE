using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Id;
    public int direction = 1;
    public int Hp = 100;
    public TextMeshPro hpText;

    public Vector3 Position
    {
        get { return transform.position; }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // 初期化処理
    void Init()
    {
        UpdateHPText();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("弾に当たった: " + other.name);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("A" + damage);
        Hp -= damage;
        UpdateHPText();
        if (Hp <= 0)
        {
            UpdateHPText();
            //Die();  // HPが0以下になった場合、プレイヤーが死亡
        }
    }

    void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = Hp.ToString();  // HPの値をテキストとして表示
        }
    }
}
