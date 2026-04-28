using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TextUIManager : MonoBehaviour, ITextUIManager
{
    public float displayTime = 1f;
    public float fadeDuration = 1f;
    private CanvasGroup _canvasGroup;
    private TextMeshProUGUI _text;
    private ICoroutineRunner _coroutineRunner;
    private Coroutine fadeCoroutine;
    private SignalBus _signalBus;
    private string[] _actionTexts;

    [Inject]
    public void Construct(
        CanvasGroup canvasGroup, 
        TextMeshProUGUI text,
        ICoroutineRunner coroutineRunner,
        SignalBus signalBus)
    {
        Debug.Log(canvasGroup == null ? "NULL" : "OK");
        Debug.Log(text == null ? "NULL" : "OK");
        Debug.Log(signalBus == null ? "NULL" : "OK");
        _canvasGroup = canvasGroup;
        _text = text;
        _coroutineRunner = coroutineRunner;
        _signalBus = signalBus;
        _signalBus.Subscribe<InputManagerSignal>(OnGenerate);
    }

    public void OnGenerate(InputManagerSignal signal)
    {
        Debug.Log("OnGenerated");
        signal.Instance.OnSignal += Handle;

        // スキル・行動などを登録
        // 順番や総数を変えないこと
        _actionTexts = new string[]
        {
            "A",        // A
            "B",        // B
            "C",        // C
            "D",        // D
            "E",        // E
            "F",        // F
            "G",        // G
            "H",        // H
            "Ike!",        // I
            "J",        // J
            "K",        // K
            "L",        // L
            "Modore!",        // M
            "N",        // N
            "O",        // O
            "P",        // P
            "Q",        // Q
            "R",        // R
            "S",        // S
            "T",        // T
            "Ute!",        // U
            "V",        // V
            "W",        // W
            "X",        // X
            "Y",        // Y
            "Z",        // Z
        };
    }

    public void Handle(InputSignal text)
    {
        // UIに表示
        _text.text = _actionTexts[(int)text];;

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
