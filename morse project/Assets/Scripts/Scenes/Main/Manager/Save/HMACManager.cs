using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class HMACManager : IHMACManager
{
    public string Create(string data)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(Consts.EncryptionKey);

        using HMACSHA256 hmac = new HMACSHA256(keyBytes);

        byte[] hash =
            hmac.ComputeHash(Encoding.UTF8.GetBytes(data));

        return Convert.ToBase64String(hash);
    }
}
