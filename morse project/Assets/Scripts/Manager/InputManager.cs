using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour, IInputManager
{
    // 判定のしきい値
    public float dotThreshold = 0.2f;   // これ未満 → ・
    public float letterPause = 0.5f;    // この時間入力がなければ文字確定

    private float pressStartTime;
    private bool isPressing = false;
    private List<string> currentSignal = new List<string>();
    private float lastInputTime;
    private Dictionary<string, Action> _actions = new();
    private Action<string> _changeText;
    private Action _pauseMenu;

    // モールス辞書
    private Dictionary<string, string> morseDict = new Dictionary<string, string>()
    {
        {".-", "A"}, {"-...", "B"}, {"-.-.", "C"}, {"-..", "D"}, {".", "E"},
        {"..-.", "F"}, {"--.", "G"}, {"....", "H"}, {"..", "I"}, {".---", "J"},
        {"-.-", "K"}, {".-..", "L"}, {"--", "M"}, {"-.", "N"}, {"---", "O"},
        {".--.", "P"}, {"--.-", "Q"}, {".-.", "R"}, {"...", "S"}, {"-", "T"},
        {"..-", "U"}, {"...-", "V"}, {".--", "W"}, {"-..-", "X"}, {"-.--", "Y"},
        {"--..", "Z"}
    };

    [Inject]
    public void Construct()
    {
        // A〜Zを登録可能にする（初期化）
        for (char key = 'A'; key <= 'Z'; key++)
        {
            _actions[key.ToString()] = null;
        }
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

        // Escが押されたとき
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu?.Invoke();
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
        // 入力したアクションを実行
        _actions[signal]?.Invoke();
        _changeText?.Invoke(signal);
    }

    public void RegisterAction(string signal, Action action)
    {
        Debug.Log(signal + ":" + action);
        _actions[signal] += action;
    }

    public void RegisterChangeTextAction(Action<string> action)
    {
        _changeText += action;
    }

    public void RegisterPauseMenu(Action action)
    {
        _pauseMenu += action;
    }
}
