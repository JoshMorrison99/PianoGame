using System;
using System.Collections;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine;

public class MidiMagic : MonoBehaviour
{

    public PianoNoteSpawner spawner;


    private Playback _playback;
    private OutputDevice _outputDevice;

    private event Action enentClone;

    // Start is called before the first frame update
    void Awake()
    {
        var midiFile = MidiFile.Read("./Assets/MidiFiles/AlanWalker-Faded.mid");
        _outputDevice = OutputDevice.GetById(0);

        _playback = midiFile.GetPlayback(_outputDevice, new MidiClockSettings
        {
            CreateTickGeneratorCallback = () => null
        }) ;


        //_playback.NotesPlaybackFinished += Test;   // Subscribing to playback event

        // Change midi length the english AKA metric
        PersistentData.data.myMidi = midiFile;
        

        _playback.NotesPlaybackFinished += spawner.spawnNote;
        _playback.InterruptNotesOnStop = true;
        StartCoroutine(StartMusic());

        

    }

    private void Test(object sender, NotesEventArgs notesArgs)
    {
        var notesList = notesArgs.Notes;
        foreach (Note item in notesList)
        {
            Debug.Log(item);
            //spawner.spawnNote(item.ToString(), 0.3f);
        }
    }
    private IEnumerator StartMusic()
    {
        _playback.Start();
        while (_playback.IsRunning)
        {
            _playback.TickClock();
            yield return null;

        }
        _playback.Dispose();
    }

    private void Update()
    {
        
    }

}
