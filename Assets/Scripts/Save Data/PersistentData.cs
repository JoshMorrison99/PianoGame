using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
//Gets all the data into one class and one constructor
//From Brackeys Save and Load System in Unity

//[System.Serializable]
public class PersistentData : MonoBehaviour, ISaveable
{
    //Temp Persistent Data
    public int selectedSong;
    public float songSpeed;
    public bool isPaused;

    // Persistent Player Information
    public int level;
    public int exp;
    public int musicNotes;
    public string username;
    public int songsComplete;
    public int songsUnlocked;

    // Persistent Player Song Progress
    public float song_Ode_To_Joy_Completion;
    public float song_See_you_Again_Completion;

    public static PersistentData data;

    private void Start()
    {
        LoadJsonData(this);
    }

    private void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        SaveJsonData(this);
    }

    // -------------------
    // Saving and Loading
    // -------------------

    public static void SaveJsonData(PersistentData a_GameViewController)
    {
        PersistentDataInformation sd = new PersistentDataInformation();
        a_GameViewController.PopulateSaveData(sd);

        if (FileManager.WriteToFile("SaveData01.dat", sd.ToJson()))
        {
            Debug.Log("Save Successful");
        }
    }

    public static void LoadJsonData(PersistentData a_GameViewController)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out var json))
        {
            PersistentDataInformation sd = new PersistentDataInformation();
            sd.LoadFromJson(json);

            a_GameViewController.LoadFromSaveData(sd);
            Debug.Log("Load Complete");
        }
    }

    public void PopulateSaveData(PersistentDataInformation a_SaveData)
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
        a_SaveData.m_song_See_you_Again_Completion = song_See_you_Again_Completion;
    }

    public void LoadFromSaveData(PersistentDataInformation a_SaveData)
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
        song_See_you_Again_Completion = a_SaveData.m_song_See_you_Again_Completion;
    }
}

public class FileManager
{
    public static bool WriteToFile(string a_FileName, string a_FileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            File.WriteAllText(fullPath, a_FileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to {fullPath} with exception {e}");
        }

        return false;
    }

    public static bool LoadFromFile(string a_FileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from {fullPath} with exception {e}");
            result = "";
            return false;
        }
    }
}



