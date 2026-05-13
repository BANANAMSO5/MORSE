using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class MissionTracker : IMissionTracker
{
    private IMissionResolver _resolver;
    private IMissionUIManager _missionUIManager;
    private Dictionary<string, MissionProgress> progressMap = new();
    private MissionProgressPanelData _data;

    [Inject]
    public void Construct(
        IMissionResolver resolver, 
        IMissionUIManager missionUIManager
    )
    {
        _resolver = resolver;
        _missionUIManager = missionUIManager;
    }

    // TODO: 機能多いかも
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

        // ミッションの経過パネル表示
        _data.TargetText = definition.Text;
        _data.Progress = progress.Count;
        _data.Goal = target;
        _missionUIManager.AddMissionProgress(_data);

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
