using System.Collections.Generic;
using System;
using System.Linq;

/// <summary>
/// Data holder in savefile.
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

    /// <summary>
    /// Section content.
    /// </summary>
    private List<EntityData> content;

    #endregion

    public Section(string sectionId, List<EntityData> data)
    {
        SectionId = sectionId;
        content = data;
    }

    public void AppendData(EntityData data)
    {
        content.Add(data);
    }

    public void RemoveData(EntityData data)
    {
        content.Remove(data);
    }

    public IReadOnlyList<EntityData> GetContent()
    {
        return content.AsReadOnly();
    }

    public List<T> GetAllDataOfType<T>() where T : EntityData
    {
        return content.Where(x => x.GetType() == typeof(T)).Select(x => (T)x).ToList();
    }
}
