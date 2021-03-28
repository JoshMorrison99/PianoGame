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
    public int m_money;

    // Persistent Player Song Import Data
    public int m_songImportIndex;

    // Persistent Player Song Progress
    public float m_song_Ode_To_Joy_Completion;
    public float m_song_See_you_Again_Completion;

    // Song List
    public List<SongData> m_SongList = new List<SongData>();

    [System.Serializable]
    public struct SongData
    {
        public int m_songID;
        public string m_SongTitle;
        public string m_SongAuthor;
        public int m_highScore;
        public int m_plays;
        public string  m_stars;
        public int m_totalNote;
        public int m_notesHit;
        public float m_songCompletionPercentage;
        public string _Difficulty;
    }

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