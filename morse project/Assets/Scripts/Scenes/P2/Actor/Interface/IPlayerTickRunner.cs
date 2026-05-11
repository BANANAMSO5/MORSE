using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerTickRunner
{
    public void Add(ITickAction action);
}
