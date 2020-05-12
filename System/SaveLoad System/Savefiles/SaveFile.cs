using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Savedata container which holds <see cref="Section"/>'s with <see cref="EntityData"/> in them.
/// </summary>
[System.Serializable]
public class SaveFile
{
    #region Public_Members

    /// <summary>
    /// Savefile name.
    /// </summary>
    public string Name;

    #endregion

    #region Private_Members

    [SerializeField]
    /// <summary>
    /// All savefile sections.
    /// </summary>
    private List<Section> sections = new List<Section>();

    #endregion

    /// <summary>
    /// Add new <see cref="Section"/> to the savefile.
    /// </summary>
    /// <param name="section"></param>
    public void AddSection(Section section)
    {
        sections.Add(section);
    }

    /// <summary>
    /// Remove <see cref="Section"/> from the savefile.
    /// </summary>
    /// <param name="sectionId">Section-to-remove id</param>
    public void RemoveSection(string sectionId)
    {
        if (sectionId == SaveLoadManager.MAIN_SECTION_NAME) return;
        var section = sections.Find(x => x.SectionId == sectionId);
        if (section.Equals(default)) return;
        sections.Remove(section);
    }

    /// <summary>
    /// Get all sections (readonly).
    /// </summary>
    /// <returns></returns>
    public IReadOnlyList<Section> GetAllSections()
    {
        return sections.AsReadOnly();
    }

    /// <summary>
    /// Serialize savefile in json format.
    /// </summary>
    /// <param name="encrypt">Do we need data to be encrypted?</param>
    /// <returns></returns>
    public string ToJson(bool encrypt)
    {
        string json = JsonUtility.ToJson(this, true);
        return encrypt ? System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json)) : json;
    }
}
