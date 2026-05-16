using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DataEncrypter : IDataEncrypter
{
    public string Encrypt(string plainText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(Consts.EncryptionKey.PadRight(32));

        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] encryptedBytes =
                encryptor.TransformFinalBlock(
                    plainBytes, 0, plainBytes.Length);

            byte[] combined =
                new byte[aes.IV.Length + encryptedBytes.Length];

            Buffer.BlockCopy(aes.IV, 0, combined, 0, aes.IV.Length);

            Buffer.BlockCopy(
                encryptedBytes, 0,
                combined, aes.IV.Length,
                encryptedBytes.Length);

            return Convert.ToBase64String(combined);
        }
    }
}
