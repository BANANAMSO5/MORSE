using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;
using static InputChar;
using static InputSignal;

/// <summary>
/// 入力した文字をイベント発火する
/// </summary>
public class InputManager : MonoBehaviour, IInputManager
{
    // 判定のしきい値
    public float dotThreshold = 0.2f;   // これ未満 → ・
    public float letterPause = 0.5f;    // この時間入力がなければ文字確定
    public event Action<InputChar> OnFixChar;
    public event Action OnDotSignal;
    public event Action OnDashSignal;
    public event Action OnEndSignal;
    [Inject] SignalBus _signalBus;

    private float pressStartTime;
    private bool isPressing = false;
    private List<string> currentSignal = new List<string>();
    private float lastInputTime;
    private Action _pauseMenu;

    // モールス辞書
    private Dictionary<string, InputChar> morseDict = new Dictionary<string, InputChar>()
    {
        {".-", A}, {"-...", B}, {"-.-.", C}, {"-..", D}, {".", E},
        {"..-.", F}, {"--.", G}, {"....", H}, {"..", I}, {".---", J},
        {"-.-", K}, {".-..", L}, {"--", M}, {"-.", N}, {"---", O},
        {".--.", P}, {"--.-", Q}, {".-.", R}, {"...", S}, {"-", T},
        {"..-", U}, {"...-", V}, {".--", W}, {"-..-", X}, {"-.--", Y},
        {"--..", Z}
    };
    

    [Inject]
    public void Construct()
    {
        enabled = false;
        // bool _isLocalPlayer = playerId == TestGameManager.Id;
        // enabled = _isLocalPlayer;
    }

    void Start()
    {
        // _signalBus.Fire(new InputManagerSignal{ Instance = this });
    }

    public void Setenable(int id)
    {
        bool _isLocalPlayer = id == TestGameManager.Id;
        enabled = _isLocalPlayer;
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
                OnDotSignal?.Invoke();
                Debug.Log("・");
            }
            else
            {
                currentSignal.Add("-");
                OnDashSignal?.Invoke();
                Debug.Log("－");
            }

            lastInputTime = Time.time;
        }

        // 一定時間入力がなければ文字確定
        if (!isPressing && currentSignal.Count > 0)
        {
            if (Time.time - lastInputTime > letterPause)
            {
                OnEndSignal.Invoke();

                // 文字変換できる信号か
                string signal = string.Join("", currentSignal);
                if (morseDict.TryGetValue(signal, out InputChar result))
                {
                    // 文字ならInvoke
                    OnFixChar?.Invoke(result);
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
