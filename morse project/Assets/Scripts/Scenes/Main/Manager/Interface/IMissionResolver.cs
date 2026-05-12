using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMissionResolver
{
    Dictionary<string, MissionDefinition> GetAll();
    MissionDefinition GetFromId(string id);
}
