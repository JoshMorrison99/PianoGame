using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour, ISaveable
{

    public static PersistentData Instance;

    public int selectedSong;

    // Persistent Player Information
    public int level;
    public int exp;
    public int musicNotes;
    public string username;
    public int songsComplete;
    public int songsUnlocked;

    // Persistent Player Song Progress
    public int song_Ode_To_Joy_Completion;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        LoadJsonData(this);
        
    }

    private void OnApplicationQuit()
    {
        SaveJsonData(this);
    }

    public static void SaveJsonData(PersistentData persistentData)
    {
        SaveData sd = new SaveData();
        persistentData.PopulateSaveData(sd);


        if (FileManager.WriteToFile("SaveData01.dat", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public static void LoadJsonData(PersistentData persistentData)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            persistentData.LoadFromSaveData(sd);

            Debug.Log("Load complete");
        }
    }

    public void PopulateSaveData(SaveData a_SaveData)
    {
        // Player Info
        a_SaveData.m_level = level;
        a_SaveData.m_exp = exp;
        a_SaveData.m_musicNotes = musicNotes;
        a_SaveData.m_songsComplete = songsComplete;
        a_SaveData.m_songsUnlocked = songsUnlocked;
        a_SaveData.m_username = username;

        // Player Song Progress
        a_SaveData.m_song_Ode_To_Joy_Completion = song_Ode_To_Joy_Completion;
    }

    public void LoadFromSaveData(SaveData a_SaveData)
    {
        // Player Info
        level = a_SaveData.m_level;
        exp = a_SaveData.m_exp;
        musicNotes = a_SaveData.m_musicNotes;
        songsComplete = a_SaveData.m_songsComplete;
        songsUnlocked = a_SaveData.m_songsUnlocked;
        username = a_SaveData.m_username;

        // Player Song Progress
        song_Ode_To_Joy_Completion = a_SaveData.m_song_Ode_To_Joy_Completion;
    }
}
