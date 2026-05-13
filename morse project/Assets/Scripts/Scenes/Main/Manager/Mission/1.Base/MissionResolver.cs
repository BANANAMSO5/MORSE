using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MissionResolver : IMissionResolver
{
    private Dictionary<string, MissionDefinition> map;

    [Inject]
    public void Construct(
        IMissionCsvLoader loader,
        IMissionCsvHolder holder)
    {
        var defs = loader.Load(holder.Csv);

        map = defs.ToDictionary(x => x.Id);
    }

    public Dictionary<string, MissionDefinition> GetAll()
    {
        return map;
    }

    public MissionDefinition GetFromId(string id)
    {
        // TODO: 例外処理
        return map[id];
    }
}
