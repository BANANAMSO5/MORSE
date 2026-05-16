using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : ISaveDataManager
{
    public event Action<SaveData> OnScoreChanged;
    public SaveData SaveData => _saveData;
    private SaveData _saveData;

    public void Construct()
    {
        _saveData = new SaveData();
    }

    // TODO:いったん全部セット
    public void SetData(SaveData value)
    {
        _saveData = value;
    }
}
