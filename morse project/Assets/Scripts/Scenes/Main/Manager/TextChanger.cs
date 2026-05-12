using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : ITextChanger
{
    public void ChangeText(InputChar input, TextMeshProUGUI textMesh)
    {
        textMesh.text = Consts.Alphabets[(int)input].ToString();
    }
}
