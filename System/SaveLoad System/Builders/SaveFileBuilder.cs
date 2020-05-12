using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Save builder.
/// </summary>
public class SaveFileBuilder
{
    #region Private_Members

    /// <summary>
    /// Currently building save.
    /// </summary>
    private SaveFile save;

    #endregion

    public SaveFileBuilder()
    {
        save = new SaveFile();
    }

    /// <summary>
    /// Add new section to the savefile (only if savefile doesn't already contain such section).
    /// </summary>
    /// <param name="section">Section to add</param>
    /// <returns></returns>
    public SaveFileBuilder AddSection(Section section)
    {
        save.AddSection(section);
        return this;
    }

    /// <summary>
    /// Build savefile.
    /// </summary>
    /// <returns></returns>
    public SaveFile Build()
    {
        return save;
    }
}
