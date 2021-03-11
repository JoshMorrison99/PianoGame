using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersistentDataInformation
{

    // Persistent Player Information
    public int m_level;
    public int m_exp;
    public int m_musicNotes;
    public string m_username;
    public int m_songsComplete;
    public int m_songsUnlocked;

    // Persistent Player Song Progress
    public float m_song_Ode_To_Joy_Completion;

    
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(PersistentDataInformation a_SaveData);
    void LoadFromSaveData(PersistentDataInformation a_SaveData);
}