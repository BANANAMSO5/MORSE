using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem breakEffect;

    // ダメージを受けたときに呼ぶ
    public void PlayBreakEffect(Vector3 position)
    {
        // 発生場所をダメージ位置に合わせる
        breakEffect.transform.position = position;
        // 再生
        breakEffect.Play();
    }
}
