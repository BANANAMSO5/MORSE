using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class IndexUIManager : MonoBehaviour, IPointerClickHandler
{
    private IPanelState _panelState;
    private IPanelSlider _panelSlider;
    
    [Inject]
    public void Construct(
        IPanelState panelState, 
        IPanelSlider panelSlider
    )
    {
        _panelState = panelState;
        _panelSlider = panelSlider;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _panelSlider.Slide(_panelState);
    }
}
