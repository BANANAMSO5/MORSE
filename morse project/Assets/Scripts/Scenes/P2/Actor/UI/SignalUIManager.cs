using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// InputManagerの「・」「ー」の入力を受け取り、Panal表示を生成する
/// </summary>
public class SignalUIManager : MonoBehaviour, ISignalUIManager
{
    private IInputManager _inputManager;
    private DotSignalPanelFactory _dotFactory;
    private DashSignalPanelFactory _dashFactory;
    private List<IPanel> _panels = new();
    private List<Transform> _areas = new();

    [Inject]
    public void Construct(
        IInputManager inputManager,
        DotSignalPanelFactory dotFactory, 
        DashSignalPanelFactory dashFactory, 
        SignalPanelArea signalPanelArea
    )
    {
        Debug.Log(inputManager);
        _inputManager = inputManager;
        _inputManager.OnDotSignal += () => { if (_panels.Count <_areas.Count) DotHandle(); };
        _inputManager.OnDashSignal += () => { if (_panels.Count <_areas.Count) DashHandle(); };
        _inputManager.OnEndSignal += EndSignalHandle;
        Debug.Log("SignalUIManager");
        _dotFactory = dotFactory;
        _dashFactory = dashFactory;
        _areas = new(){ signalPanelArea.Area1, signalPanelArea.Area2, signalPanelArea.Area3, signalPanelArea.Area4 };
    }

    // 「・」のパネルを表示
    public void DotHandle()
    {
         IPanel signalPanel = _dotFactory.Create();
         _panels.Add(signalPanel);
         (signalPanel as MonoBehaviour).transform.SetParent(_areas[_panels.Count - 1], false);
    }

    // 「ー」のパネルを表示
    public void DashHandle()
    {
         IPanel signalPanel = _dashFactory.Create();
         _panels.Add(signalPanel);
         (signalPanel as MonoBehaviour).transform.SetParent(_areas[_panels.Count - 1], false);
    }

    // 入力が終了したらパネルを全削除
    public void EndSignalHandle()
    {
         _panels.ForEach(x => Destroy((x as MonoBehaviour).gameObject));
         _panels.Clear();
    }
}
