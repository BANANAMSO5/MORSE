using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUIManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float displayTime = 1f;
    public float fadeDuration = 1f;
    public TextMeshProUGUI text;
    Coroutine fadeCoroutine;

    public void Show(string _text)
    {
        text.text = _text;

        // 既存のコルーチンを止める
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }
        fadeCoroutine = StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(displayTime);

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = 1f - (time / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
