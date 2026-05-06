using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectManager : MonoBehaviour
{
    public float duration = 0.2f;   // 揺れる時間
    public float magnitude = 0.3f;  // 揺れの強さ

    [HideInInspector]
    public GameObject playerObject;
    
    [HideInInspector]
    public GameObject mainCamera;

    Player player;
    private Vector3 originalPos;

    void Start()
    {
        originalPos = mainCamera.transform.localPosition;
        
        player = playerObject.GetComponent<Player>();
        //player.OnDamage += Shake;
    }

    void OnDestroy()
    {
        //player.OnDamage -= Shake;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }
}
