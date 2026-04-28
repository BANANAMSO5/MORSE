using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    public int Hp = 100;
    public Action OnDamage;
    public Action OnDeath;
    public TextMeshPro hpText;
    private int _playerId;

    [Inject]
    public void Construct(int playerId)
    {
        _playerId = playerId;
        UpdateHPText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("弾に当たった: " + other.name);
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        OnDamage?.Invoke();
        UpdateHPText();
        if (Hp <= 0)
        {
            OnDeath.Invoke();
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
