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

    // Song List
    public List<SongData> m_SongList = new List<SongData>();

    // Item List
    public List<ItemData> m_ItemList = new List<ItemData>();

    [System.Serializable]
    public struct SongData
    {
        public int m_songID;
        public string m_SongTitle;
        public string m_SongAuthor;
        public string m_FileName;
        public int m_highScore;
        public int m_plays;
        public string  m_stars;
        public int m_totalNote;
        public int m_notesHit;
        public float m_songCompletionPercentage;
        public string _Difficulty;
    }

    [System.Serializable]
    public struct ItemData
    {
        public int m_id;
        public int m_price;
        public bool m_isPurchased;
        public string m_itemName;
        public bool m_isCurrentlySelected;
        public string m_itemType;
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