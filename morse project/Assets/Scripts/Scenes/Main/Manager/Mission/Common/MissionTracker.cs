using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MissionTracker : IMissionTracker
{
    private IMissionResolver _resolver;

    private Dictionary<string, MissionProgress> progressMap = new();

    [Inject]
    public void Construct(IMissionResolver resolver)
    {
        _resolver = resolver;
    }

    public void AddProgress(string missionId)
    {
        if (!progressMap.ContainsKey(missionId))
        {
            progressMap[missionId] =
                new MissionProgress
                {
                    MissionId = missionId
                };
        }

        var progress = progressMap[missionId];

        progress.Count++;

        var definition = _resolver.GetFromId(missionId);

        int target =
            definition.Milestones[
                progress.MilestoneIndex];

        Debug.Log(
            $"{missionId}: " +
            $"{progress.Count}/{target}");

        if (progress.Count >= target)
        {
            Debug.Log($"{missionId} 達成!");

            if (progress.MilestoneIndex <
                definition.Milestones.Length - 1)
            {
                progress.MilestoneIndex++;
            }
        }
    }
}
