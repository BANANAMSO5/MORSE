using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Consts
{
    // 順番や総数を変えないこと
    public static readonly char[] Alphabets = new char[]
    {
        'A',        // A
        'B',        // B
        'C',        // C
        'D',        // D
        'E',        // E
        'F',        // F
        'G',        // G
        'H',        // H
        'I',        // I
        'J',        // J
        'K',        // K
        'L',        // L
        'M',        // M
        'N',        // N
        'O',        // O
        'P',        // P
        'Q',        // Q
        'R',        // R
        'S',        // S
        'T',        // T
        'U',        // U
        'V',        // V
        'W',        // W
        'X',        // X
        'Y',        // Y
        'Z',        // Z
    };

    // TODO: あとでかえる
    public static readonly string EncryptionKey = "YOUR_SECRET_KEY_32BYTE";
    public static readonly string SaveDataPath = Path.Combine(Application.persistentDataPath, "save.dat");
}
