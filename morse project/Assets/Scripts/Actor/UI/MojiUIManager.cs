using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MojiUIManager : MonoBehaviour, IMojiUIManager
{
    public float displayTime = 1f;
    public float fadeDuration = 1f;
    private CanvasGroup _canvasGroup;
    private TextMeshProUGUI _textMesh;
    
    private IInputManager _inputManager;
    private ITextChanger _textChanger;

    [Inject]
    public void Construct(
        CanvasGroup canvasGroup, 
        TextMeshProUGUI textMesh,
        IInputManager inputManager,
        ITextChanger textChanger)
    {
        _canvasGroup = canvasGroup;
        _textMesh = textMesh;
        _inputManager = inputManager;
        _inputManager.OnFixChar += Handle;
        _textChanger = textChanger;
    }

    public void Handle(InputChar inputChar)
    {
        // UIに表示
        _textChanger.ChangeText(inputChar, _textMesh);

        // // 既存のコルーチンを止める
        // if (fadeCoroutine != null)
        // {
        //     _coroutineRunner.StopProcess(fadeCoroutine);
        // }
        // fadeCoroutine = _coroutineRunner.StartProcess(FadeOutRoutine());
    }

    // IEnumerator FadeOutRoutine()
    // {
    //     _canvasGroup.alpha = 1f;

    //     yield return new WaitForSeconds(displayTime);

    //     float time = 0f;

    //     while (time < fadeDuration)
    //     {
    //         time += Time.deltaTime;
    //         _canvasGroup.alpha = 1f - (time / fadeDuration);
    //         yield return null;
    //     }

    //     _canvasGroup.alpha = 0f;
    // }
}
