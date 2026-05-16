using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveDataManager
{
    SaveData SaveData { get; }
    void SetData(SaveData value);
}
