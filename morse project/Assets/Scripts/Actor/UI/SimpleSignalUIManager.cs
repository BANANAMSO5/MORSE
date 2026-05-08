using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleSignalUIManager : MonoBehaviour, ISignalUIManager
{
    private IInputManager _inputManager;
    private DotSignalPanelFactory _dotFactory;
    private DashSignalPanelFactory _dashFactory;
    private List<SignalPanel> _panels = new();
    private IPanelAssigner _assigner;

    [Inject]
    public void Construct(
        IInputManager inputManager,
        DotSignalPanelFactory dotFactory, 
        DashSignalPanelFactory dashFactory, 
        IPanelAssigner assigner
    )
    {
        _inputManager = inputManager;
        _inputManager.OnDotSignal += DotHandle;
        _inputManager.OnDashSignal += DashHandle;
        _inputManager.OnEndSignal += EndSignalHandle;
        _dotFactory = dotFactory;
        _dashFactory = dashFactory;
        _assigner = assigner;
    }

    // 「・」のパネルを表示
    public void DotHandle()
    {
         SignalPanel signalPanel = _dotFactory.Create();
         _assigner.Add(signalPanel);
    }

    // 「ー」のパネルを表示
    public void DashHandle()
    {
         SignalPanel signalPanel = _dashFactory.Create();
        _assigner.Add(signalPanel);
    }

    // 入力が終了したらパネルを全削除
    public void EndSignalHandle()
    {
         _assigner.Period();
    }
}
