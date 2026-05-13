using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        List<TextMeshProUGUI> texts
    )
    {
        slider.value = data.Progress / data.Goal;
        
        var descriptionText = texts.FirstOrDefault(t => t.name == "Description");
        var progressText = texts.FirstOrDefault(t => t.name == "Progress");

        if (descriptionText != null)
            descriptionText.text = data.TargetText.Trim();

        if (progressText != null)
            progressText.text = data.Progress.ToString() + "/" + data.Goal.ToString();
    }
}
