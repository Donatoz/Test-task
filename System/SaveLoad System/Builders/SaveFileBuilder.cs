using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <see cref="SaveFile"/> builder.
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
    /// Add new <see cref="Section"/> to the <see cref="SaveFile"/> (only if savefile doesn't already contain such section).
    /// </summary>
    /// <param name="section">Section to add</param>
    /// <returns></returns>
    public SaveFileBuilder AddSection(Section section)
    {
        save.AddSection(section);
        return this;
    }

    public SaveFileBuilder Rename(string name)
    {
        save.Name = name;
        return this;
    }

    /// <summary>
    /// Build new <see cref="SaveFile"/>.
    /// </summary>
    /// <returns></returns>
    public SaveFile Build()
    {
        return save;
    }
}
