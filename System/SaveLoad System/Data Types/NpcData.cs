using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

[Serializable]
public class NpcData : ActorData
{
    public List<EntityData> SomeList = new List<EntityData>();

    public override string ToString()
    {
        var result = $"NPC {Name} - {ReferenceId} which contains:\n";
        SomeList.ForEach(x => result += $"{x.ToString()}\n");
        return result;
    }
}
