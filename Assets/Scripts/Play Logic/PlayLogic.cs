using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{

    public int songNumber;
    public float numNotesTotal;
    public float numNotesHit;

    public int currentScore;

    public MidiMagic myMidi;
    public PianoNoteSpawner spawner;
    public PlayUILogic UILogic;

    // Start is called before the first frame update
    void Start()
    {

        currentScore = 0;

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();
        spawner.noteSpeed = 0.05f;
        PersistentData.data.songSpeed = 0.05f;

        UILogic = GameObject.Find("Canvas").GetComponent<PlayUILogic>();


        numNotesHit = 0;

        songNumber = PersistentData.data.selectedSong;
        Debug.Log(PersistentData.data.userSongSelected);
        // Add song
        try
        {
            
            string path = Path.Combine(Application.streamingAssetsPath, "/MidiFiles/" + PersistentData.data.userSongSelected);
            Debug.Log(path);
            Debug.Log(Application.streamingAssetsPath);
            Debug.Log(Path.Combine(Application.streamingAssetsPath, "/MidiFiles/" + PersistentData.data.userSongSelected));
            myMidi.ActivateMidi(Application.streamingAssetsPath + "/MidiFiles/" + PersistentData.data.userSongSelected);
        }
        catch (Exception err)
        {
            Debug.Log(err);
        }
        try
        {
            
            myMidi.ActivateMidi(Application.streamingAssetsPath + "/MidiFiles/UserMidiFiles/" + PersistentData.data.userSongSelected);
        }
        catch (Exception err)
        {
            Debug.Log(err);
        }

        numNotesTotal = myMidi.midiFile.GetNotes().Count;

    }
}
