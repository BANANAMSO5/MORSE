using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissionCsvLoader : IMissionCsvLoader
{
    public List<MissionDefinition> Load(TextAsset csv)
    {
        var lines = csv.text
            .Split('\n')
            .Skip(1);

        var result = new List<MissionDefinition>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var cols = line.Split(',');

            var def = new MissionDefinition
            {
                Id = cols[0],

                Type = cols[1],

                Milestones = cols[2]
                    .Replace("\"", "")
                    .Split('|')
                    .Select(int.Parse)
                    .ToArray()
            };

            result.Add(def);
        }

        return result;
    }
}
