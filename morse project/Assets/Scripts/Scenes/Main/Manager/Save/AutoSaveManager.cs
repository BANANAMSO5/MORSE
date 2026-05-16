using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AutoSaveManager : IAutoSaveManager
{
    private IDataSaver _dataSaver;
    private ISaveDataManager _saveDataManager;
    private IObjectService _objectService;

    [Inject]
    public void Construct(
        IDataSaver dataSaver, 
        ISaveDataManager saveDataManager, 
        IObjectService objectService
    )
    {
        _dataSaver = dataSaver;
        _saveDataManager = saveDataManager;
        _objectService = objectService;
        _objectService.StartProcess(AutoSave());
    }

    IEnumerator AutoSave()
    {
        while (true)
        {
            if (_saveDataManager.SaveData != null)
            {
                _dataSaver.Save(_saveDataManager.SaveData);
                Debug.Log("セーブ実施");
            }

            yield return new WaitForSeconds(10f);
        }
    }
}
