using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.Linq;

[Serializable]
public class ActorData : EntityData
{
    public Dictionary<string, int> Stats = new Dictionary<string, int>();

    public override string ToString()
    {
        var result = $"Actor {Name} - {ReferenceId} with stats:\n";
        Stats.ToList().ForEach(x => result += $"{x.Key} : {x.Value}\n");
        return result;
    }
}
