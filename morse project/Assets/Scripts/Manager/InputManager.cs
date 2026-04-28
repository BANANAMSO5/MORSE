using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;
using static InputSignal;

/// <summary>
/// 入力した文字をイベント発火する
/// </summary>
public class InputManager : MonoBehaviour, IInputManager
{
    // 判定のしきい値
    public float dotThreshold = 0.2f;   // これ未満 → ・
    public float letterPause = 0.5f;    // この時間入力がなければ文字確定
    public event Action<InputSignal> OnSignal;
    [Inject] SignalBus _signalBus;

    private float pressStartTime;
    private bool isPressing = false;
    private List<string> currentSignal = new List<string>();
    private float lastInputTime;
    private Action<string> _changeText;
    private Action _pauseMenu;

    // モールス辞書
    private Dictionary<string, InputSignal> morseDict = new Dictionary<string, InputSignal>()
    {
        {".-", A}, {"-...", B}, {"-.-.", C}, {"-..", D}, {".", E},
        {"..-.", F}, {"--.", G}, {"....", H}, {"..", I}, {".---", J},
        {"-.-", K}, {".-..", L}, {"--", M}, {"-.", N}, {"---", O},
        {".--.", P}, {"--.-", Q}, {".-.", R}, {"...", S}, {"-", T},
        {"..-", U}, {"...-", V}, {".--", W}, {"-..-", X}, {"-.--", Y},
        {"--..", Z}
    };
    

    [Inject]
    public void Construct(int playerId)
    {
        bool _isLocalPlayer = playerId == TestGameManager.Id;

        Debug.Log("_isLocalPlayer:" + _isLocalPlayer);
        enabled = _isLocalPlayer;
    }

    void Start()
    {
        _signalBus.Fire(new InputManagerSignal{ Instance = this });
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
                // 文字変換できる信号か
                string signal = string.Join("", currentSignal);
                if (morseDict.TryGetValue(signal, out InputSignal result))
                {
                    // 文字ならInvoke
                    OnSignal?.Invoke(result);
                }
                currentSignal.Clear();
            }
        }

        // Escが押されたとき
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu?.Invoke();
        }
    }
}

public class InputManagerSignal
{
    public InputManager Instance;
}
