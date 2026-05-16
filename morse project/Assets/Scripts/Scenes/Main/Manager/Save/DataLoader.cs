using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class DataLoader : IDataLoader
{
    private IDataDecrypter _dataDecrypter;
    private IHMACManager _HMACManagerMAC;

    [Inject]
    public void Construct(
        IDataDecrypter dataDecrypter, 
        IHMACManager HMACManagerMAC
    )
    {
        _dataDecrypter = dataDecrypter;
        _HMACManagerMAC = HMACManagerMAC;
    }
    
    public SaveData Load()
    {
        if (!File.Exists(Consts.SaveDataPath))
            return new SaveData();

        string wrapperJson = File.ReadAllText(Consts.SaveDataPath);

        EncryptedSaveData wrapper =
            JsonUtility.FromJson<EncryptedSaveData>(wrapperJson);

        // 改ざんチェック
        string newHash = _HMACManagerMAC.Create(wrapper.data);

        if (newHash != wrapper.hash)
        {
            Debug.LogError("セーブデータ改ざん検知");
            return new SaveData();
        }

        string json = _dataDecrypter.Decrypt(wrapper.data);

        return JsonUtility.FromJson<SaveData>(json);
    }
}
