using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMissionCsvLoader
{
    List<MissionDefinition> Load(TextAsset csv);
}
