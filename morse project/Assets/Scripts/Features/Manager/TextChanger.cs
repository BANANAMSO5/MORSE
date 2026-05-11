using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : ITextChanger
{
    // スキル・行動などを登録
    // 順番や総数を変えないこと
    private string[] _actionTexts = new string[]
    {
        "A",        // A
        "B",        // B
        "C",        // C
        "D",        // D
        "E",        // E
        "F",        // F
        "G",        // G
        "H",        // H
        "I",        // I
        "J",        // J
        "K",        // K
        "L",        // L
        "M",        // M
        "N",        // N
        "O",        // O
        "P",        // P
        "Q",        // Q
        "R",        // R
        "S",        // S
        "T",        // T
        "U",        // U
        "V",        // V
        "W",        // W
        "X",        // X
        "Y",        // Y
        "Z",        // Z
    };

    public void ChangeText(InputChar input, TextMeshProUGUI textMesh)
    {
        textMesh.text = _actionTexts[(int)input];
    }
}
