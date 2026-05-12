using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class WordChecker : IWordChecker
{
    private IMissionTracker _missionTracker;
    private string current = "";
    private Dictionary<string, MissionDefinition> _words;

    [Inject]
    public void Construct(
        IMissionTracker missionTracker,
        IMissionResolver resolver
    )
    {
        _missionTracker = missionTracker;
        _words = resolver.GetAll();
    }

    public void Check(InputChar input)
    {
        current += char.ToUpper(Consts.Alphabets[(int)input]);

        // 前方一致する単語があるか
        bool hasPrefix = _words.Any(w => w.Value.Type.StartsWith(current));

        if (!hasPrefix)
        {
            Debug.Log("Reset");
            current = "";
            return;
        }

        var id = _words.First(w => w.Value.Type == current).Key;

        if (id != null)
        {
            Debug.Log($"Matched: {id}");
            _missionTracker.AddProgress(id);
        }
    }
}
