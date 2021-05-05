using System;
using System.Collections;
using System.Collections.Generic;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine;

public class MidiMagic : MonoBehaviour
{

    public PianoNoteSpawner spawner;
    public PlayUILogic UILogic;

    public bool isFirstRun = true;


    public Playback _playback;
    public Playback _playback_audio;

    public OutputDevice _outputDevice;
    public MidiFile midiFile;


    public void ActivateMidi(string Midi_path)
    {
        
        midiFile = MidiFile.Read(Midi_path);
        _outputDevice = OutputDevice.GetById(0);

        // Note Playback
        _playback = midiFile.GetPlayback( new MidiClockSettings
        {
            CreateTickGeneratorCallback = () => null
        });

        // Audio Playback
        _playback_audio = midiFile.GetPlayback(_outputDevice, new MidiClockSettings
        {
            CreateTickGeneratorCallback = () => null
        });

        //Debug.Log("TOTAL NOTES: " + midiFile.GetNotes().Count);

        //Debug.Log(_outputDevice.SupportsLeftRightVolumeControl);
        //Debug.Log(_outputDevice.SupportsVolumeControl);
        //Debug.Log(_outputDevice.Channels);


        // Set the volume the same as player prefs
        GetAndSetSongVolume();

        // Set the speed of the playback
        SongSpeedSliderChangedValue();

        isFirstRun = true;


        // Change midi length the english AKA metric
        PersistentData.data.myMidi = midiFile;
        PersistentData.data.myPlayback = _playback;
        PersistentData.data.myPlaybackAudio = _playback_audio;
        _playback.NotesPlaybackStarted += spawner.spawnNote;
        
        _playback.InterruptNotesOnStop = true;
        _playback_audio.InterruptNotesOnStop = true;

        Debug.Log("VOLUME: " + _outputDevice.Volume);
        Debug.Log("VOLUME Device: " + _outputDevice.Name);
        ResumePlayback();

    }

    public void ChangeMidiPlaybackSpeed(float speed)
    {
        _playback.Speed = speed;
        _playback_audio.Speed = speed;
    }

    public void GetAndSetSongVolume()
    {
        float newSongVolume = PlayerPrefs.GetFloat("Volume");
        Debug.Log("Volume " + newSongVolume);
        const int volumeUIntMutiplier = 65535;
        ChangedMidiPlaybackVolume(newSongVolume * volumeUIntMutiplier);
    }

    public void SongSpeedSliderChangedValue()
    {
        float newSongSpeed = PlayerPrefs.GetFloat("Speed");
        Debug.Log("Speed is now: " + newSongSpeed);
        ChangeMidiPlaybackSpeed(newSongSpeed);
    }

    public void ChangedMidiPlaybackVolume(float volume)
    {
        ushort newVolume = (ushort)volume;
        if (_outputDevice.SupportsVolumeControl)
        {
            try
            {
                _outputDevice.Volume = new Volume(newVolume);
                Debug.Log(_outputDevice.Volume.LeftVolume);
                Debug.Log(_outputDevice.Volume.RightVolume);
                Debug.Log(newVolume);
            }catch(Exception e)
            {
                Debug.Log(e);
            }
            
        }
    }


    public void ResumePlayback()
    {
        StartCoroutine(StartMusic());
        StartCoroutine(StartAudio());
    }





    private IEnumerator StartMusic()
    {
        _playback.Start();
        while (_playback.IsRunning || PersistentData.data.isPaused)
        {
            
             
            if ( PersistentData.data.isPaused == false)
            {
                //Debug.Log("ACTIVE StartMusic=========");
                _playback.TickClock();
            }
            
            yield return null;

        }

        Debug.Log("ENDED StartMusic");

        yield return new WaitForSeconds(6f);

        UILogic.UpdateFinishedSongText();


        _playback.Dispose();
       

    }

    private IEnumerator StartAudio()
    {
        if (isFirstRun)
        {
            yield return new WaitForSeconds(3.2f);
            isFirstRun = false;
        }
        _playback_audio.Start();
        while (_playback_audio.IsRunning || PersistentData.data.isPaused)
        {

             
            if (PersistentData.data.isPaused == false)
            {
                //Debug.Log("ACTIVE StartAudio------");
                _playback_audio.TickClock();
            }

            yield return null;

        }

        Debug.Log("ENDED --StartAudio");

        yield return new WaitForSeconds(9.2f);

        //UILogic.UpdateFinishedSongText();


        _playback_audio.Dispose();


    }

    public void ReplaySong()
    {
        Debug.Log("Dispose Playback");
        _playback.Dispose();
        _playback_audio.Dispose();
        _outputDevice.Dispose();
    }



}
