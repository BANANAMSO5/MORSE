using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MissionProgressPanel : MonoBehaviour, IPanel
{
    [Inject]
    public void Construct(
        MissionProgressPanelData data,
        Slider slider, 
        TextMeshProUGUI text
    )
    {
        Debug.Log("value:" + data.Progress);
        slider.value = data.Progress;
        text.text = data.TargetText;
    }
}
