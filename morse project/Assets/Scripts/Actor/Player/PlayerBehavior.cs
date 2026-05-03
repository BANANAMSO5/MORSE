using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerBehavior : MonoBehaviour, IPlayerBehavior
{
    public IISignalAction ISignalAction { get; set; }
    public IMSignalAction MSignalAction { get; set; }
    public IUSignalAction USignalAction { get; set; }

    [Inject]
    public void Construct(
        IISignalAction iSignalAction,
        IMSignalAction mSignalAction,
        IUSignalAction uSignalAction
    )
    {
        ISignalAction = iSignalAction;
        MSignalAction = mSignalAction;
        USignalAction = uSignalAction;
    }
}
