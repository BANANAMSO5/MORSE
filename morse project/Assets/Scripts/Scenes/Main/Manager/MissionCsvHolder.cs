using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCsvHolder : IMissionCsvHolder
{
    public TextAsset Csv { get; }

    public MissionCsvHolder(TextAsset csv)
    {
        Csv = csv;
    }
}
