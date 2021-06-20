using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Core;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Melanchall.DryWetMidi.Interaction;
//Gets all the data into one class and one constructor
//From Brackeys Save and Load System in Unity

//[System.Serializable]
public class PersistentData : MonoBehaviour, ISaveable
{
    // Play Modes
    public bool StutterMode = false;
    public bool StubbornMode = false;
    public bool TimelineActivate = false;
    public bool stutterModeLogic = false;
    public List<GameObject> canStutterModeAdvance = new List<GameObject>();


    //Temp Persistent Data
    public int selectedSong;
    public float songSpeed;
    public bool isPaused;
    public float songStartPlayerExp;
    public bool isLevellingUp;

    public GameObject templateSong;

    public string ThemeName;
    public Color NoteLightColor;
    public Color SharpNoteLightColor;
    public Color ThemeNoteColor;
    public Color ThemeSharpNoteColor;
    public VideoClip ThemePianoBar;
    public Color ThemeKeyColor;

    public MidiFile myMidi;
    public Playback myPlayback;
    public Playback myPlaybackAudio;

    public string userSongSelected;


    // Persistent Player Information
    public int level;
    public int exp;
    public int musicNotes;
    public string username;
    public int songsComplete;
    public int songsUnlocked;
    public int money;

    // Persistent Player Song Import Data
    public int songImportIndex;

    // Persistent Song Information
    public List<SongInfo> _SongList = new List<SongInfo>();

    public static PersistentData data;

    private void Start()
    {
        songImportIndex = 0;

        if (!File.Exists(Application.persistentDataPath + "/SaveData01.dat"))
        {
            Debug.Log("NOT EXISTS " + Application.persistentDataPath + "/SaveData01.dat");
            SetTotalSongNotes();
            ThemeName = "Default";
            PlayerPrefs.SetString("Theme", "Default");
            SaveJsonData(this);
        }
        LoadJsonData(this);

        //SaveJsonData(this);             // During development Activate this function first to reset the song list
        ThemeName = PlayerPrefs.GetString("Theme");
    }

    public void SetTotalSongNotes()
    {

        foreach (var song in _SongList)
        {
            try{
                string currentSong = song.GetComponent<SongInfo>()._FileName;
                MidiFile midiFile = MidiFile.Read(Application.dataPath + "/StreamingAssets/MidiFiles/" + currentSong);
                int numNotesTotal = midiFile.GetNotes().Count;
                song.GetComponent<SongInfo>()._totalNote = numNotesTotal;
                SaveJsonData(this);
            }
            catch (Exception err)
            {
                Debug.Log(err);
            }
        }
    }

    private void Awake()
    {
        if (data != null && data != this)
        {
            Destroy(gameObject);
        }
        else
        {
            data = this;
            DontDestroyOnLoad(gameObject);
        }
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
            //Debug.Log("Save Successful");
        }
    }

    public static void LoadJsonData(PersistentData a_GameViewController)
    {
        if (FileManager.LoadFromFile("SaveData01.dat", out var json))
        {
            PersistentDataInformation sd = new PersistentDataInformation();
            sd.LoadFromJson(json);

            a_GameViewController.LoadFromSaveData(sd);
            //Debug.Log("Load Complete");
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
        a_SaveData.m_money = money;

        a_SaveData.m_songImportIndex = songImportIndex;

        

        // Song Information
        foreach (SongInfo song in _SongList)
        {
            //Debug.Log("song.LoadFromSaveData: " + song);
            song.PopulateSaveData(a_SaveData);
        }
        
        

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
        money = a_SaveData.m_money;

        songImportIndex = a_SaveData.m_songImportIndex;


        _SongList.Clear();

        GameObject SongHolder = GameObject.Find("Songs");

        // Song Information
        //Debug.Log(a_SaveData.m_SongList.Count);
        for (int i = 0; i < a_SaveData.m_SongList.Count; i++)
        {
            GameObject newSong = Instantiate(templateSong);
            newSong.GetComponent<SongInfo>()._SongTitle = a_SaveData.m_SongList[i].m_SongTitle;
            newSong.GetComponent<SongInfo>()._SongAuthor = a_SaveData.m_SongList[i].m_SongAuthor;
            newSong.GetComponent<SongInfo>()._FileName = a_SaveData.m_SongList[i].m_FileName;
            newSong.GetComponent<SongInfo>()._plays = a_SaveData.m_SongList[i].m_plays;
            newSong.GetComponent<SongInfo>()._notesHit = a_SaveData.m_SongList[i].m_notesHit;
            newSong.GetComponent<SongInfo>()._highScore = a_SaveData.m_SongList[i].m_highScore;
            newSong.GetComponent<SongInfo>()._Difficulty = a_SaveData.m_SongList[i]._Difficulty;
            newSong.GetComponent<SongInfo>()._songID = a_SaveData.m_SongList[i].m_songID;
            newSong.GetComponent<SongInfo>()._stars = a_SaveData.m_SongList[i].m_stars;
            newSong.GetComponent<SongInfo>()._songCompletionPercentage = a_SaveData.m_SongList[i].m_songCompletionPercentage;
            newSong.GetComponent<SongInfo>()._totalNote = a_SaveData.m_SongList[i].m_totalNote;
            _SongList.Add(newSong.GetComponent<SongInfo>());

            newSong.transform.SetParent(SongHolder.transform);
        }
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



