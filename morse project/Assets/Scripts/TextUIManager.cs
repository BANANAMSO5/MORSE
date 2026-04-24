using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TextUIManager : ITextUIManager
{
    public float displayTime = 1f;
    public float fadeDuration = 1f;
    private CanvasGroup _canvasGroup;
    private TextMeshProUGUI _text;
    private ICoroutineRunner _coroutineRunner;
    Coroutine fadeCoroutine;

    [Inject]
    public void Construct(
        CanvasGroup canvasGroup, 
        TextMeshProUGUI text,
        ICoroutineRunner coroutineRunner)
    {
        _canvasGroup = canvasGroup;
        _text = text;
        _coroutineRunner = coroutineRunner;
    }

    public void ChangeText(string text)
    {
        _text.text = text;

        // 既存のコルーチンを止める
        if (fadeCoroutine != null)
        {
            _coroutineRunner.StopProcess(fadeCoroutine);
        }
        fadeCoroutine = _coroutineRunner.StartProcess(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        _canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(displayTime);

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            _canvasGroup.alpha = 1f - (time / fadeDuration);
            yield return null;
        }

        _canvasGroup.alpha = 0f;
    }
}
