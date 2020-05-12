using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

/// <summary>
/// Manager that handles saving, loading and creating <see cref="SaveFile"/>'s.
/// </summary>
public class SaveLoadManager : MonoBehaviour
{
    #region Singleton
    private SaveLoadManager() { }

    public static SaveLoadManager Instance => GameObject.Find("GameManagers").GetComponent<SaveLoadManager>();
    #endregion

    #region Constants

    /// <summary>
    /// Main section name in each savefile.
    /// </summary>
    public const string MAIN_SECTION_NAME = "Main";

    #endregion

    #region Public_Members

    /// <summary>
    /// Path which is used for saving files.
    /// </summary>
    public string SaveFilesPath;
    /// <summary>
    /// Currently loaded savefile.
    /// </summary>
    public SaveFile CurrentSave;

    #endregion

    #region Private_Members

    /// <summary>
    /// Special buffer for holding data which must be serialized and written into savefile.
    /// </summary>
    private List<EntityData> dataBuffer = new List<EntityData>();

    #endregion

    private void Awake()
    {
        // Check "Assets/StreamingAssets" folder for savefile
        SaveFilesPath = Application.streamingAssetsPath + "/Saves/";
    }

    private void Start()
    {
        DebugSave();
    }

    /// <summary>
    /// For debugging purposes.
    /// </summary>
    private void DebugSave()
    {
        Dictionary<string, int> testStats = new Dictionary<string, int>();
        testStats["Health"] = 10;
        dataBuffer.Add(new EntityData() { Name = "Ent1", ReferenceId = "1" });
        dataBuffer.Add(new ActorData() { Name = "Ent2", ReferenceId = "2", Stats = testStats });
        Section unnecessarySection = new Section("Unnecessary", new List<EntityData> { new EntityData() { Name = "Ent3", ReferenceId = "3" } });
        Section otherSection = new Section("Other", new List<EntityData> { new EntityData() { Name = "Ent4", ReferenceId = "4" } });

        SaveFile save = CreateSaveFile("Test", dataBuffer, unnecessarySection);
        WriteSave(save);
        LoadSave("Test");
        Debug.Log(CurrentSave.Name);
        Debug.Log(CurrentSave.GetAllSections().Count);

        CurrentSave.RemoveSection("Unnecessary");
        CurrentSave.AddSection(otherSection);

        WriteSave(CurrentSave);
        LoadSave("Test");
        Debug.Log(CurrentSave.GetAllSections()[0].GetAllDataOfType<ActorData>()[0].Stats["Health"]);
    }

    /// <summary>
    /// Create new savefile with name and some sections (if provided).
    /// </summary>
    /// <param name="saveName">Name of the new savefile</param>
    /// <param name="mainSectionContent">Content of the main section</param>
    /// <param name="sections">Additional sections</param>
    /// <returns></returns>
    public SaveFile CreateSaveFile(string saveName, List<EntityData> mainSectionContent, params Section[] sections)
    {
        SaveFileBuilder builder = new SaveFileBuilder();
        builder.AddSection(new Section(MAIN_SECTION_NAME, mainSectionContent));
        sections.ToList().ForEach(x => builder.AddSection(x));

        SaveFile save = builder.Build();
        save.Name = saveName;
        return save;
    }

    /// <summary>
    /// Write <see cref="SaveFile"/> (if savefile doesn't exist - create one) to the savefiles path.
    /// </summary>
    /// <param name="save">Savefile to write</param>
    public void WriteSave(SaveFile save)
    {
        string data = DataSerializer.SerializeObject(save);
        if (!Directory.Exists(SaveFilesPath))
            Directory.CreateDirectory(SaveFilesPath);
        File.WriteAllText(SaveFilesPath + save.Name + ".txt", data);
    }

    /// <summary>
    /// Load <see cref="SaveFile"/> (if exists) from savefiles path.
    /// </summary>
    /// <param name="saveName">Savefile name</param>
    public void LoadSave(string saveName)
    {
        string data = File.ReadAllText(SaveFilesPath + saveName + ".txt");
        CurrentSave = DataSerializer.DeserializeObject<SaveFile>(data);
    }

    /// <summary>
    /// Remove data from buffer (if buffer contains it).
    /// </summary>
    /// <param name="data">Data to remove</param>
    public void RemoveSaveData(EntityData data)
    {
        dataBuffer.Remove(data);
    }

    /// <summary>
    /// Add data to buffer.
    /// </summary>
    /// <param name="data">Data parts</param>
    public void AddSaveData(params EntityData[] data)
    {
        foreach(EntityData d in data)
        {
            dataBuffer.Add(d);
        }
    }
}
