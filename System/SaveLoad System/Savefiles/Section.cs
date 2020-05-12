using System.Collections.Generic;
using System;
using System.Linq;

/// <summary>
/// Data holder in <see cref="SaveFile"/>.
/// </summary>
[Serializable]
public struct Section
{
    #region Public_Members

    /// <summary>
    /// Section unique id.
    /// </summary>
    public string SectionId;

    #endregion

    #region Private_Members

    [UnityEngine.SerializeField]
    /// <summary>
    /// Section content.
    /// </summary>
    private List<EntityData> content;

    #endregion

    public Section(string sectionId, List<EntityData> data)
    {
        SectionId = sectionId;
        if (data != null)
            content = data;
        else
            content = new List<EntityData>();
    }

    /// <summary>
    /// Add <see cref="EntityData"/> to the section (if section doesn't already cointain this data).
    /// </summary>
    /// <param name="data">Data to add</param>
    public void AppendData(EntityData data)
    {
        if (content.Contains(data)) return;
        content.Add(data);
    }

    /// <summary>
    /// Remove <see cref="EntityData"/> from the section.
    /// </summary>
    /// <param name="data">Data to remove</param>
    public void RemoveData(EntityData data)
    {
        content.Remove(data);
    }

    /// <summary>
    /// Get whole content of the section (as <see cref="IReadOnlyList{T}"/>).
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<EntityData> GetContent()
    {
        return content.AsReadOnly();
    }

    /// <summary>
    /// Get all data of specific type in section.
    /// </summary>
    /// <typeparam name="T">Data type (derived from <see cref="EntityData"/>)</typeparam>
    /// <returns></returns>
    public List<T> GetAllDataOfType<T>() where T : EntityData
    {
        return content.Where(x => x.GetType() == typeof(T)).Select(x => (T)x).ToList();
    }
}
