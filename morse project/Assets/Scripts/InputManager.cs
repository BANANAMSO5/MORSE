using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public MoveManager mm;
    public BulletManager bm;

    float pressStartTime;
    bool isPressing = false;

    List<string> currentSignal = new List<string>();

    // 判定のしきい値
    public float dotThreshold = 0.2f;   // これ未満 → ・
    public float letterPause = 0.5f;    // この時間入力がなければ文字確定

    float lastInputTime;

    // モールス辞書
    Dictionary<string, string> morseDict = new Dictionary<string, string>()
    {
        {".-", "A"}, {"-...", "B"}, {"-.-.", "C"}, {"-..", "D"}, {".", "E"},
        {"..-.", "F"}, {"--.", "G"}, {"....", "H"}, {"..", "I"}, {".---", "J"},
        {"-.-", "K"}, {".-..", "L"}, {"--", "M"}, {"-.", "N"}, {"---", "O"},
        {".--.", "P"}, {"--.-", "Q"}, {".-.", "R"}, {"...", "S"}, {"-", "T"},
        {"..-", "U"}, {"...-", "V"}, {".--", "W"}, {"-..-", "X"}, {"-.--", "Y"},
        {"--..", "Z"}
    };

    // Start is called before the first frame update
    void Start()
    {
        //mm = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキー押した瞬間
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressStartTime = Time.time;
            isPressing = true;
        }

        // 離した瞬間
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float pressDuration = Time.time - pressStartTime;
            isPressing = false;

            if (pressDuration < dotThreshold)
            {
                currentSignal.Add(".");
                Debug.Log("・");
            }
            else
            {
                currentSignal.Add("-");
                Debug.Log("－");
            }

            lastInputTime = Time.time;
        }

        // 一定時間入力がなければ文字確定
        if (!isPressing && currentSignal.Count > 0)
        {
            if (Time.time - lastInputTime > letterPause)
            {
                DecodeSignal();
                currentSignal.Clear();
            }
        }
    }

    void DecodeSignal()
    {
        string signal = string.Join("", currentSignal);

        if (morseDict.TryGetValue(signal, out string result))
        {
            // 判定処理
            JudgeSignal(result);
            Debug.Log("入力: " + signal + " → " + result);
        }
        else
        {
            Debug.Log("入力: " + signal + " → 不明");
        }
    }

    void JudgeSignal(string signal)
    {
        // Ike
        if (signal == "I")
        {
            mm.MoveRight();
        }
        // Modore
        else if (signal == "M")
        {
            mm.MoveLeft();
        }
        // Ute
        else if (signal == "U")
        {
            bm.Shot();
        }
    }
}
