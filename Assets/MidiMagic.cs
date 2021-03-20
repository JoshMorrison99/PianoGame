using System;
using System.Collections;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine;

public class MidiMagic : MonoBehaviour
{

    public PianoNoteSpawner spawner;


    public Playback _playback;
    public OutputDevice _outputDevice;


    public void ActivateMidi(string Midi_path)
    {
        
        var midiFile = MidiFile.Read(Midi_path);
        _outputDevice = OutputDevice.GetById(0);

        _playback = midiFile.GetPlayback(_outputDevice, new MidiClockSettings
        {
            CreateTickGeneratorCallback = () => null
        });


        // Change midi length the english AKA metric
        PersistentData.data.myMidi = midiFile;
        PersistentData.data.myPlayback = _playback;
        _playback.NotesPlaybackStarted += spawner.spawnNote;
       
        _playback.InterruptNotesOnStop = true;
        ResumePlayback();
    }


    public void ResumePlayback()
    {
        StartCoroutine(StartMusic());
    }


    private IEnumerator StartMusic()
    {
        _playback.Start();
        while (_playback.IsRunning || PersistentData.data.isPaused)
        {
            
            // Debug.Log("ACTIVE");
            if ( PersistentData.data.isPaused == false)
            {
                _playback.TickClock();
            }
            
            yield return null;

        }
    
        //_playback.Dispose();
       

    }

}
