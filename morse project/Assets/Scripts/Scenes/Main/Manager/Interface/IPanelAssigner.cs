using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPanelAssigner
{
    void Add(IPanel panel, Transform parent);
    void Period();
}
