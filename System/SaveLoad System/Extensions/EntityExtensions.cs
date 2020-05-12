using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extension methods for <see cref="EntityData"/> and inherited classes.
/// </summary>
public static class EntityExtensions
{
    /// <summary>
    /// Get <see cref="EntityData"/> as <see cref="ActorData"/>.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ActorData AsActorData(this EntityData data)
    {
        return data as ActorData;
    }

    /// <summary>
    /// Get <see cref="ActorData"/> as <see cref="NpcData"/>.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static NpcData AsNpcData(this ActorData data)
    {
        return data as NpcData;
    }

    /// <summary>
    /// Get <see cref="ActorData"/> as <see cref="PlayerData"/>.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static PlayerData AsPlayerData(this ActorData data)
    {
        return data as PlayerData;
    }
}
