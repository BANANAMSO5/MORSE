using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerBehavior
{
    IISignalAction ISignalAction { get; }
    IMSignalAction MSignalAction { get; }
    IUSignalAction USignalAction { get; }
}
