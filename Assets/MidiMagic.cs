using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        // Set the volume the same as player prefs
        GetAndSetSongVolume();

        // Set the speed of the playback
        SongSpeedSliderChangedValue();

        isFirstRun = true;

        GetDurationOfMidi();

        // Change midi length the english AKA metric
        PersistentData.data.myMidi = midiFile;
        PersistentData.data.myPlayback = _playback;
        PersistentData.data.myPlaybackAudio = _playback_audio;
        _playback.NotesPlaybackStarted += spawner.spawnNoteEfficient;

        _playback.InterruptNotesOnStop = true;
        _playback_audio.InterruptNotesOnStop = true;

        Debug.Log("VOLUME: " + _outputDevice.Volume);
        Debug.Log("VOLUME Device: " + _outputDevice.Name);
        ResumePlayback();

        PlaybackCurrentTimeWatcher.Instance.AddPlayback(_playback_audio, TimeSpanType.Midi);
        PlaybackCurrentTimeWatcher.Instance.CurrentTimeChanged += spawner.OnCurrentTimeChanged;
        PlaybackCurrentTimeWatcher.Instance.Start();
    }

   public void GetDurationOfMidi()
    {
        var tempoMap = midiFile.GetTempoMap();
        var TimeOfLastEvent = midiFile.GetTimedEvents().Last().TimeAs<MetricTimeSpan>(tempoMap);

        var MidiTime = midiFile.GetTimedEvents().Last().TimeAs<MidiTimeSpan>(tempoMap);

        spawner.endTimeValue = MidiTime;

        spawner.endTime.text = TimeOfLastEvent.Minutes.ToString() + ":" + (TimeOfLastEvent.Seconds < 10 ? "0" + TimeOfLastEvent.Seconds.ToString() : TimeOfLastEvent.Seconds.ToString());
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
        while (_playback.IsRunning || PersistentData.data.isPaused || PersistentData.data.StutterModeStrict || PersistentData.data.StutterModeChill)
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
            yield return new WaitForSeconds(3.3f);
            isFirstRun = false;
        }
        _playback_audio.Start();
        while (_playback_audio.IsRunning || PersistentData.data.isPaused || PersistentData.data.StutterModeStrict || PersistentData.data.StutterModeChill)
        {

             
            if (PersistentData.data.isPaused == false)
            {
                //Debug.Log("ACTIVE StartAudio------");
                _playback_audio.TickClock();
                PlaybackCurrentTimeWatcher.Instance.TickClock();
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
