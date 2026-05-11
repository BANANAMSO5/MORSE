using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelAssigner
{
    void Add(SignalPanel panel, Transform parent);
    void Period();
}
