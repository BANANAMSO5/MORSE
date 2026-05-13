using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class WordChecker : IFactorChecker
{
    private IMissionTracker _missionTracker;
    private string current = "";
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
        current += char.ToUpper(Consts.Alphabets[(int)input]);

        // 前方一致する単語があるか
        bool hasPrefix = _missions.Any(w => w.Value.Target.Trim().StartsWith(current));

        if (!hasPrefix)
        {
            Debug.Log("Reset");
            current = "";
            return;
        }

        var id = _missions.FirstOrDefault(w => w.Value.Target.Trim() == current).Key;

        if (id != null)
        {
            Debug.Log($"Matched: {id}");
            _missionTracker.AddProgress(id);
        }
    }
}
