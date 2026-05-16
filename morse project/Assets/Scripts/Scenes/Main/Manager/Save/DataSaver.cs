using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using Zenject;

public class DataSaver : IDataSaver
{
    private IDataEncrypter _dataEncrypter;
    private IHMACManager _HMACManagerMAC;

    [Inject]
    public void Construct(
        IDataEncrypter dataEncrypter, 
        IHMACManager HMACManagerMAC
    )
    {
        _dataEncrypter = dataEncrypter;
        _HMACManagerMAC = HMACManagerMAC;
    }

    public void Save(SaveData saveData)
    {
        string json = JsonUtility.ToJson(saveData);
        string encrypted = _dataEncrypter.Encrypt(json);
        string hash = _HMACManagerMAC.Create(encrypted);

        EncryptedSaveData encryptedSave = new EncryptedSaveData
        {
            data = encrypted,
            hash = hash
        };

        File.WriteAllText(Consts.SaveDataPath, JsonUtility.ToJson(encryptedSave));
    }
}
