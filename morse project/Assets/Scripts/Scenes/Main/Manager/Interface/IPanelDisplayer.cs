using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelDisplayer
{
    bool IsProcessing { get; }
    event Action OnFinished;
    void Display(List<RectTransform> rects);
}
