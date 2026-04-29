using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// InputManagerの「・」「ー」の入力を受け取り、Panal表示を生成する
/// </summary>
public class SignalUIManager : MonoBehaviour, ISignalUIManager
{
    private DotSignalPanelFactory _dotFactory;
    private DashSignalPanelFactory _dashFactory;
    private SignalBus _signalBus;
    private List<SignalPanel> _panels = new();
    private List<Transform> _areas = new();

    [Inject]
    public void Construct(
        SignalBus signalBus, 
        DotSignalPanelFactory dotFactory, 
        DashSignalPanelFactory dashFactory, 
        SignalPanelArea signalPanelArea
    )
    {
        Debug.Log("SignalUIManager");
        _signalBus = signalBus;
        _signalBus.Subscribe<InputManagerSignal>(OnGenerate);
        _dotFactory = dotFactory;
        _dashFactory = dashFactory;
        _areas = new(){ signalPanelArea.Area1, signalPanelArea.Area2, signalPanelArea.Area3, signalPanelArea.Area4 };
    }

    // InputManager(Player)が生成されたときに入力時の処理を登録
    public void OnGenerate(InputManagerSignal signal)
    {
        signal.Instance.OnDotSignal += () => { if (_panels.Count <_areas.Count) DotHandle(); };
        signal.Instance.OnDashSignal += () => { if (_panels.Count <_areas.Count) DashHandle(); };
        signal.Instance.OnEndSignal += EndSignalHandle;
    }

    // 「・」のパネルを表示
    public void DotHandle()
    {
         SignalPanel signalPanel = _dotFactory.Create();
         _panels.Add(signalPanel);
         signalPanel.transform.SetParent(_areas[_panels.Count - 1], false);
    }

    // 「ー」のパネルを表示
    public void DashHandle()
    {
         SignalPanel signalPanel = _dashFactory.Create();
         _panels.Add(signalPanel);
         signalPanel.transform.SetParent(_areas[_panels.Count - 1], false);
    }

    // 入力が終了したらパネルを全削除
    public void EndSignalHandle()
    {
         _panels.ForEach(x => Destroy(x.gameObject));
         _panels.Clear();
    }
}
