using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelSlider : IPanelSlider
{
    private float slideDuration = 0.3f;
    private IObjectService _objectService;

    [Inject]
    public void Construct(IObjectService objectService)
    {
        _objectService = objectService;
    }

    public void Slide(IPanelState panel)
    {
        _objectService.StartProcess(SlideCoroutine(panel));
    }

    IEnumerator SlideCoroutine(IPanelState panel)
    {
        Vector2 startPos = panel.Rect.anchoredPosition;
        float width = panel.Width;
        Vector2 targetPos = panel.IsOpen ? new Vector2(startPos.x + width, 0) : new Vector2(startPos.x - width, 0);

        float elapsed = 0f;
        while (elapsed < slideDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / slideDuration);
            t = t * t * (3f - 2f * t);
            panel.Rect.anchoredPosition = Vector2.Lerp(startPos, targetPos, t);
            yield return null;
        }

        panel.Rect.anchoredPosition = targetPos;
        panel.IsOpen = !panel.IsOpen;
    }
}
