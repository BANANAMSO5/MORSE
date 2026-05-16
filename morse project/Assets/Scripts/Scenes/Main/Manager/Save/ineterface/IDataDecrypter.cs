using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataDecrypter
{
    string Decrypt(string cipherText);
}
