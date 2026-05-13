using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class AlphabetChecker : IFactorChecker
{
    private IMissionTracker _missionTracker;
    private Dictionary<string, MissionDefinition> _missions;

    [Inject]
    public void Construct(
        IMissionTracker missionTracker,
        IMissionResolver resolver
    )
    {
        _missionTracker = missionTracker;
        _missions = resolver.GetAll();
    }

    public void Check(InputChar input)
    {
        string alp = char.ToUpper(Consts.Alphabets[(int)input]).ToString();
        Debug.Log("alp:" + alp);

        var id = _missions.FirstOrDefault(w => w.Value.Target.Trim() == alp).Key;

        if (id != null)
        {
            Debug.Log($"Matched: {id}");
            _missionTracker.AddProgress(id);
        }
    }
}
