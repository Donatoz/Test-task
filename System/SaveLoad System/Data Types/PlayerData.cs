using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : ActorData
{
    public List<string> Inventory = new List<string>();

    public override string ToString()
    {
        var result = $"Player {Name} - {ReferenceId} with inventory:\n";
        Inventory.ForEach(x => result += $"    {x}\n");
        return result;
    }
}
