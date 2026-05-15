using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestAccordion : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform contentArea;
    [SerializeField] private RectTransform innerContent;

    [SerializeField] private float duration = 0.25f;
    [SerializeField] private bool startOpened = false;

    private bool isOpen;
    private Coroutine animationCoroutine;

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }

    private void Awake()
    {
        // 初期状態を設定
        isOpen = startOpened;

        // レイアウト情報を最新化（TextやLayoutGroupのサイズを確定させる）
        LayoutRebuilder.ForceRebuildLayoutImmediate(innerContent);

        // 開くなら中身の高さ、閉じるなら0
        float height = isOpen
            ? LayoutUtility.GetPreferredHeight(innerContent)
            : 0f;

        Vector2 size = contentArea.sizeDelta;
        size.y = height;
        contentArea.sizeDelta = size;
    }

    public void Toggle()
    {
        // すでにアニメーション中なら止める（連打対策）
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }

        // 最新のレイアウトを再計算（動的テキスト対応）
        LayoutRebuilder.ForceRebuildLayoutImmediate(innerContent);

        // 開閉先の高さを決定
        float targetHeight = isOpen
            ? 0f
            : LayoutUtility.GetPreferredHeight(innerContent);

        // アニメーション開始
        animationCoroutine = StartCoroutine(
            AnimateHeight(targetHeight)
        );

        // 状態を反転（次回のToggle用）
        isOpen = !isOpen;
    }

    private IEnumerator AnimateHeight(float targetHeight)
    {
        // 現在の高さ（アニメーション開始位置）
        float startHeight = contentArea.sizeDelta.y;

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;

            float t = Mathf.Clamp01(time / duration);
            t = Mathf.SmoothStep(0f, 1f, t);

            float height = Mathf.Lerp(
                startHeight,
                targetHeight,
                t
            );

            Vector2 size = contentArea.sizeDelta;
            size.y = height;
            contentArea.sizeDelta = size;

            if (transform.parent is RectTransform parent)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(parent);
            }

            yield return null;
        }

        // 最終値を確実にセット（誤差対策）
        Vector2 finalSize = contentArea.sizeDelta;
        finalSize.y = targetHeight;
        contentArea.sizeDelta = finalSize;

        // 最終レイアウト更新
        if (transform.parent is RectTransform finalParent)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(finalParent);
        }

        animationCoroutine = null;
    }
}
