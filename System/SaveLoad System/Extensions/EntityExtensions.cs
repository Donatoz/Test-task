using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityExtensions
{
    public static ActorData AsActorData(this EntityData data)
    {
        return data as ActorData;
    }

    public static NpcData AsNpcData(this ActorData data)
    {
        return data as NpcData;
    }

    public static PlayerData AsPlayerData(this ActorData data)
    {
        return data as PlayerData;
    }
}
