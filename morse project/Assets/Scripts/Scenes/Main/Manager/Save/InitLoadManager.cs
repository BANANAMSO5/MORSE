using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InitLoadManager : IInitLoadManager
{
    private IDataLoader _dataLoader;

    [Inject]
    public void Construct(
        IDataLoader dataLoader,
        ISaveDataManager saveDataManager
    )
    {
        _dataLoader = dataLoader;
        saveDataManager.SetData(_dataLoader.Load());
        Debug.Log("セーブデータ取得");
    }
}
