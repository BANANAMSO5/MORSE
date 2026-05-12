using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimpleSignalUIManager : MonoBehaviour, ISignalUIManager
{
    private IInputManager _inputManager;
    private DotSignalPanelFactory _dotFactory;
    private DashSignalPanelFactory _dashFactory;
    private IPanelAssigner _assigner;
    private Transform _parent;

    [Inject]
    public void Construct(
        IInputManager inputManager,
        DotSignalPanelFactory dotFactory, 
        DashSignalPanelFactory dashFactory, 
        IPanelAssigner assigner,
        Transform parent
    )
    {
        _inputManager = inputManager;
        _inputManager.OnDotSignal += DotHandle;
        _inputManager.OnDashSignal += DashHandle;
        _inputManager.OnEndSignal += EndSignalHandle;
        _dotFactory = dotFactory;
        _dashFactory = dashFactory;
        _assigner = assigner;
        _parent = parent;
    }

    // 「・」のパネルを生成
    public void DotHandle()
    {
        IPanel signalPanel = _dotFactory.Create();
        _assigner.Add(signalPanel, _parent);
    }

    // 「ー」のパネルを生成
    public void DashHandle()
    {
        IPanel signalPanel = _dashFactory.Create();
        _assigner.Add(signalPanel, _parent);
    }

    // 入力が終了したらパネルを全削除
    public void EndSignalHandle()
    {
         _assigner.Period();
    }
}
