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
    private Coroutine fadeCoroutine;

    Dictionary<string, string> skillDict = new Dictionary<string, string>()
    {
        { "A", "A" }, { "B", "B" }, { "C", "C" }, { "D", "D" }, { "E", "E" },
        { "F", "F" }, { "G", "G" }, { "H", "H" }, { "I", "Ike" }, { "J", "J" },
        { "K", "K" }, { "L", "L" }, { "M", "Modore" }, { "N", "N" }, { "O", "O" },
        { "P", "P" }, { "Q", "Q" }, { "R", "R" }, { "S", "S" }, { "T", "T" },
        { "U", "Ute" }, { "V", "V" }, { "W", "W" }, { "X", "X" }, { "Y", "Y" },
        { "Z", "Z" }
    };

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
        // UIに表示
        if (skillDict.TryGetValue(text, out string skillName))
        {
            _text.text = skillName;

            // 既存のコルーチンを止める
            if (fadeCoroutine != null)
            {
                _coroutineRunner.StopProcess(fadeCoroutine);
            }
            fadeCoroutine = _coroutineRunner.StartProcess(FadeOutRoutine());
        }
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
