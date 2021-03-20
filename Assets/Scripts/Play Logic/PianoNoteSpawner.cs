using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Devices;

public class PianoNoteSpawner : MonoBehaviour
{
    /*// Notes
    public GameObject QuarterNote;
    public GameObject HalfNote;
    public GameObject Dotted_QuarterNote;
    public GameObject EighthNote;
    public GameObject SixteenthNote;
    public GameObject WholeNote;

    // Sharps
    public GameObject QuarterSharp;
    public GameObject HalfSharp;
    public GameObject QuarterDottedSharp;
    public GameObject WholeSharp;
    public GameObject SixteenthSharp;
    public GameObject EighthSharp;*/

    public GameObject SharpNote;
    public GameObject Note;

    public PianoKeyPresses pianoListRef;

    public List<GameObject> spawnedNotes;
    public List<GameObject> garbageNotes;

    const float NOTE_DESTROY_DEPTH = -30f;

    const float SEE_YOU_AGAIN_NOTESCALE = 2f;

    public float noteSpeed = 0;

    // Piano Notes
    public GameObject C2;
    public GameObject D2;
    public GameObject E2;
    public GameObject F2;
    public GameObject G2;
    public GameObject A2;
    public GameObject B2;
    public GameObject Cs2;
    public GameObject Ds2;
    public GameObject Fs2;
    public GameObject Gs2;
    public GameObject As2;

    public GameObject C3;
    public GameObject D3;
    public GameObject E3;
    public GameObject F3;
    public GameObject G3;
    public GameObject A3;
    public GameObject B3;
    public GameObject Cs3;
    public GameObject Ds3;
    public GameObject Fs3;
    public GameObject Gs3;
    public GameObject As3;

    public GameObject C4;
    public GameObject D4;
    public GameObject E4;
    public GameObject F4;
    public GameObject G4;
    public GameObject A4;
    public GameObject B4;
    public GameObject Cs4;
    public GameObject Ds4;
    public GameObject Fs4;
    public GameObject Gs4;
    public GameObject As4;

    public GameObject C5;
    public GameObject D5;
    public GameObject E5;
    public GameObject F5;
    public GameObject G5;
    public GameObject A5;
    public GameObject B5;
    public GameObject Cs5;
    public GameObject Ds5;
    public GameObject Fs5;
    public GameObject Gs5;
    public GameObject As5;

    public GameObject C6;
    public GameObject D6;
    public GameObject E6;
    public GameObject F6;
    public GameObject G6;
    public GameObject A6;
    public GameObject B6;
    public GameObject Cs6;
    public GameObject Ds6;
    public GameObject Fs6;
    public GameObject Gs6;
    public GameObject As6;


    float noteHeight = 10f;
    float noteSharpHeight = 9.55f;

    private void Start()
    {
        setupUI();
    }

    
   

    private void FixedUpdate()
    {

        for (int i = 0; i < spawnedNotes.Count; i++)
        {
            if (spawnedNotes[i].transform.position.y > NOTE_DESTROY_DEPTH)
            {
                spawnedNotes[i].transform.position = new Vector3(spawnedNotes[i].transform.position.x, spawnedNotes[i].transform.position.y - noteSpeed, spawnedNotes[i].transform.position.z);
            }
            else
            {
                garbageNotes.Add(spawnedNotes[i]);
                spawnedNotes.RemoveAt(i);
                i--;
            }
        }

        if (garbageNotes.Count > 0)
        {
            garbageCollect();
        }



    }

    public void garbageCollect()
    {
        foreach (GameObject each in garbageNotes)
        {
            Destroy(each);
        }
    }

    public void ScaleNotes(GameObject spawnedNote)
    {
        if (PersistentData.data.selectedSong == 1)
        {
            // Scale Note Prefabs
            spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x * 1.3f, spawnedNote.transform.localScale.y * 1.3f, 0);
        }
        else if (PersistentData.data.selectedSong == 2)
        {
            spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
        }
    }

    public void spawnNote(object sender, NotesEventArgs notesArgs)
    {
        
        var notesList = notesArgs.Notes;

        Debug.Log(notesList);
        foreach (Note item in notesList)
        {
            string noteName = item.ToString();

            long ticks = 0;
            TempoMap tempoMap = PersistentData.data.myMidi.GetTempoMap();
            MetricTimeSpan metricLength = item.LengthAs<MetricTimeSpan>(tempoMap);

            float duration = ((float)metricLength.Milliseconds) / 1000;


            Debug.Log( ((float) metricLength.Milliseconds) / 1000);


            if (noteName == "C2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(C2.transform.position.x, C2.transform.position.y + noteHeight, C2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C#2")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs2.transform.position.x, C2.transform.position.y + noteSharpHeight, Cs2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(D2.transform.position.x, D2.transform.position.y + noteHeight, D2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D#2")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds2.transform.position.x, Ds2.transform.position.y + noteSharpHeight, Ds2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "E2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(E2.transform.position.x, E2.transform.position.y + noteHeight, E2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(F2.transform.position.x, F2.transform.position.y + noteHeight, F2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F#2")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs2.transform.position.x, Fs2.transform.position.y + noteSharpHeight, Fs2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(G2.transform.position.x, G2.transform.position.y + noteHeight, G2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G#2")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs2.transform.position.x, Gs2.transform.position.y + noteSharpHeight, Gs2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(A2.transform.position.x, A2.transform.position.y + noteHeight, A2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A#2")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As2.transform.position.x, As2.transform.position.y + noteSharpHeight, As2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "B2")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(B2.transform.position.x, B2.transform.position.y + noteHeight, B2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(C2.transform.position.x, C2.transform.position.y + noteHeight, C2.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C#3")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs3.transform.position.x, Cs3.transform.position.y + noteSharpHeight, Cs3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(D3.transform.position.x, D3.transform.position.y + noteHeight, D3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D#3")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds3.transform.position.x, Ds3.transform.position.y + noteSharpHeight, Ds3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "E3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(E3.transform.position.x, E3.transform.position.y + noteHeight, E3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(F3.transform.position.x, F3.transform.position.y + noteHeight, F3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F#3")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs3.transform.position.x, Fs3.transform.position.y + noteSharpHeight, Fs3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(G3.transform.position.x, G3.transform.position.y + noteHeight, G3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G#3")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs3.transform.position.x, Gs3.transform.position.y + noteSharpHeight, Gs3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(A3.transform.position.x, A3.transform.position.y + noteHeight, A3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A#3")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As3.transform.position.x, As3.transform.position.y + noteSharpHeight, As3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "B3")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(B3.transform.position.x, B3.transform.position.y + noteHeight, B3.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(C4.transform.position.x, C4.transform.position.y + noteHeight, C4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C#4")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs4.transform.position.x, C4.transform.position.y + noteSharpHeight, Cs4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(D4.transform.position.x, D4.transform.position.y + noteHeight, D4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D#4")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds4.transform.position.x, Ds4.transform.position.y + noteSharpHeight, Ds4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "E4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(E4.transform.position.x, E4.transform.position.y + noteHeight, E4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(F4.transform.position.x, F4.transform.position.y + noteHeight, F4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F#4")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs4.transform.position.x, Fs4.transform.position.y + noteSharpHeight, Fs4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(G4.transform.position.x, G4.transform.position.y + noteHeight, G4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G#4")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs4.transform.position.x, Gs4.transform.position.y + noteSharpHeight, Gs4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(A4.transform.position.x, A4.transform.position.y + noteHeight, A4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A#4")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As4.transform.position.x, As4.transform.position.y + noteSharpHeight, As4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "B4")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(B4.transform.position.x, B4.transform.position.y + noteHeight, B4.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(C5.transform.position.x, C5.transform.position.y + noteHeight, C5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C#5")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs5.transform.position.x, Cs5.transform.position.y + noteSharpHeight, Cs5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(D5.transform.position.x, D5.transform.position.y + noteHeight, D5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D#5")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds5.transform.position.x, Ds5.transform.position.y + noteSharpHeight, Ds5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "E5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(E5.transform.position.x, E5.transform.position.y + noteHeight, E5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(F5.transform.position.x, F5.transform.position.y + noteHeight, F5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F#5")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs5.transform.position.x, Fs5.transform.position.y + noteSharpHeight, Fs5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(G5.transform.position.x, G5.transform.position.y + noteHeight, G5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G#5")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs5.transform.position.x, Gs5.transform.position.y + noteSharpHeight, Gs5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(A5.transform.position.x, A5.transform.position.y + noteHeight, A5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A#5")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As5.transform.position.x, As5.transform.position.y + noteSharpHeight, As5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "B5")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(B5.transform.position.x, B5.transform.position.y + noteHeight, B5.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(C6.transform.position.x, C6.transform.position.y + noteHeight, C6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "C#6")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs6.transform.position.x, Cs6.transform.position.y + noteSharpHeight, Cs6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(D6.transform.position.x, D6.transform.position.y + noteHeight, D6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "D#6")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds6.transform.position.x, Ds6.transform.position.y + noteSharpHeight, Ds6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "E6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(E6.transform.position.x, E6.transform.position.y + noteHeight, E6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(F6.transform.position.x, F6.transform.position.y + noteHeight, F6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "F#6")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs6.transform.position.x, Fs6.transform.position.y + noteSharpHeight, Fs6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(G6.transform.position.x, G6.transform.position.y + noteHeight, G6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "G#6")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs6.transform.position.x, Gs6.transform.position.y + noteSharpHeight, Gs6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(A6.transform.position.x, A6.transform.position.y + noteHeight, A6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "A#6")
            {
                GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As6.transform.position.x, As6.transform.position.y + noteSharpHeight, As6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
            else if (noteName == "B6")
            {
                GameObject spawnedNote = Instantiate(Note, new Vector3(B6.transform.position.x, B6.transform.position.y + noteHeight, B6.transform.position.z), Quaternion.identity);
                spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
                spawnedNotes.Add(spawnedNote);
            }
        }


        /*if (isSharp)
        {
            GameObject spawnedNote = Instantiate(SharpNote, new Vector3(position.transform.position.x, position.transform.position.y + 9.55f, position.transform.position.z), Quaternion.identity);
            spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
            //ScaleNotes(spawnedNote, SharpNote);
            spawnedNotes.Add(spawnedNote);
        }
        else
        {
            GameObject spawnedNote = Instantiate(Note, new Vector3(position.transform.position.x, position.transform.position.y + 10f, position.transform.position.z), Quaternion.identity);
            //ScaleNotes(spawnedNote, SharpNote);
            spawnedNote.transform.localScale = new Vector3(spawnedNote.transform.localScale.x, spawnedNote.transform.localScale.y * duration, 0);
            spawnedNotes.Add(spawnedNote);
        }*/




        /*if (type == "HalfNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(HalfSharp, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(HalfNote.transform.localScale.x * 1.3f, HalfNote.transform.localScale.y * 1.3f, 0);
                }else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(HalfNote.transform.localScale.x, HalfNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
            else
            {
                GameObject spawnedNote = Instantiate(HalfNote, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.25f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(HalfNote.transform.localScale.x * 1.3f, HalfNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(HalfNote.transform.localScale.x, HalfNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
        } else if(type == "QuarterNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(QuarterSharp, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(QuarterNote.transform.localScale.x * 1.3f, QuarterNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(QuarterNote.transform.localScale.x, QuarterNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
            else
            {
                GameObject spawnedNote = Instantiate(QuarterNote, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.25f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(QuarterNote.transform.localScale.x * 1.3f, QuarterNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(QuarterNote.transform.localScale.x, QuarterNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
        }else if (type == "DottedQuartedNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(QuarterDottedSharp, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(Dotted_QuarterNote.transform.localScale.x * 1.3f, Dotted_QuarterNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(Dotted_QuarterNote.transform.localScale.x, Dotted_QuarterNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
            else
            {
                GameObject spawnedNote = Instantiate(Dotted_QuarterNote, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.25f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(QuarterNote.transform.localScale.x * 1.3f, QuarterNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(Dotted_QuarterNote.transform.localScale.x, Dotted_QuarterNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
        }
        else if (type == "EighthNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(EighthSharp, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(EighthNote.transform.localScale.x * 1.3f, EighthNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(EighthNote.transform.localScale.x, EighthNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
            else
            {
                GameObject spawnedNote = Instantiate(EighthNote, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.25f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(EighthNote.transform.localScale.x * 1.3f, EighthNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(EighthNote.transform.localScale.x, EighthNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
        }else if (type == "SixteenthNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(SixteenthSharp, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(SixteenthNote.transform.localScale.x * 1.3f, SixteenthNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(SixteenthNote.transform.localScale.x, SixteenthNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
            else
            {
                GameObject spawnedNote = Instantiate(SixteenthNote, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.25f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(SixteenthNote.transform.localScale.x * 1.3f, SixteenthNote.transform.localScale.y * 1.3f, 0);
                }
                else if (PersistentData.data.selectedSong == 2)
                {
                    spawnedNote.transform.localScale = new Vector3(SixteenthNote.transform.localScale.x, SixteenthNote.transform.localScale.y * SEE_YOU_AGAIN_NOTESCALE, 0);
                }
            }
        }*/

    }

    public void setupUI()
    {
        // Octave 2
        C2 = pianoListRef.PianoKeys[0];
        C2.GetComponent<Note_Mine>().noteName = "C";
        D2 = pianoListRef.PianoKeys[1];
        D2.GetComponent<Note_Mine>().noteName = "D";
        E2 = pianoListRef.PianoKeys[2];
        E2.GetComponent<Note_Mine>().noteName = "E";
        F2 = pianoListRef.PianoKeys[3];
        F2.GetComponent<Note_Mine>().noteName = "F";
        G2 = pianoListRef.PianoKeys[4];
        G2.GetComponent<Note_Mine>().noteName = "G";
        A2 = pianoListRef.PianoKeys[5];
        A2.GetComponent<Note_Mine>().noteName = "A";
        B2 = pianoListRef.PianoKeys[6];
        B2.GetComponent<Note_Mine>().noteName = "B";
        Cs2 = pianoListRef.PianoKeys[7];
        Cs2.GetComponent<Note_Mine>().noteName = "C#";
        Ds2 = pianoListRef.PianoKeys[8];
        Ds2.GetComponent<Note_Mine>().noteName = "D#";
        Fs2 = pianoListRef.PianoKeys[9];
        Fs2.GetComponent<Note_Mine>().noteName = "F#";
        Gs2 = pianoListRef.PianoKeys[10];
        Gs2.GetComponent<Note_Mine>().noteName = "G#";
        As2 = pianoListRef.PianoKeys[11];
        As2.GetComponent<Note_Mine>().noteName = "A#";

        // Octave 3
        C3 = pianoListRef.PianoKeys[12];
        C3.GetComponent<Note_Mine>().noteName = "C";
        D3 = pianoListRef.PianoKeys[13];
        D3.GetComponent<Note_Mine>().noteName = "D";
        E3 = pianoListRef.PianoKeys[14];
        E3.GetComponent<Note_Mine>().noteName = "E";
        F3 = pianoListRef.PianoKeys[15];
        F3.GetComponent<Note_Mine>().noteName = "F";
        G3 = pianoListRef.PianoKeys[16];
        G3.GetComponent<Note_Mine>().noteName = "G";
        A3 = pianoListRef.PianoKeys[17];
        A3.GetComponent<Note_Mine>().noteName = "A";
        B3 = pianoListRef.PianoKeys[18];
        B3.GetComponent<Note_Mine>().noteName = "B";
        Cs3 = pianoListRef.PianoKeys[19];
        Cs3.GetComponent<Note_Mine>().noteName = "C#";
        Ds3 = pianoListRef.PianoKeys[20];
        Ds3.GetComponent<Note_Mine>().noteName = "D#";
        Fs3 = pianoListRef.PianoKeys[21];
        Fs3.GetComponent<Note_Mine>().noteName = "F#";
        Gs3 = pianoListRef.PianoKeys[22];
        Gs3.GetComponent<Note_Mine>().noteName = "G#";
        As3 = pianoListRef.PianoKeys[23];
        As3.GetComponent<Note_Mine>().noteName = "A#";

        // Octave 4
        C4 = pianoListRef.PianoKeys[24];
        C4.GetComponent<Note_Mine>().noteName = "C";
        D4 = pianoListRef.PianoKeys[25];
        D4.GetComponent<Note_Mine>().noteName = "D";
        E4 = pianoListRef.PianoKeys[26];
        E4.GetComponent<Note_Mine>().noteName = "E";
        F4 = pianoListRef.PianoKeys[27];
        F4.GetComponent<Note_Mine>().noteName = "F";
        G4 = pianoListRef.PianoKeys[28];
        G4.GetComponent<Note_Mine>().noteName = "G";
        A4 = pianoListRef.PianoKeys[29];
        A4.GetComponent<Note_Mine>().noteName = "A";
        B4 = pianoListRef.PianoKeys[30];
        B4.GetComponent<Note_Mine>().noteName = "B";
        Cs4 = pianoListRef.PianoKeys[31];
        Cs4.GetComponent<Note_Mine>().noteName = "C#";
        Ds4 = pianoListRef.PianoKeys[32];
        Ds4.GetComponent<Note_Mine>().noteName = "D#";
        Fs4 = pianoListRef.PianoKeys[33];
        Fs4.GetComponent<Note_Mine>().noteName = "F#";
        Gs4 = pianoListRef.PianoKeys[34];
        Gs4.GetComponent<Note_Mine>().noteName = "G#";
        As4 = pianoListRef.PianoKeys[35];
        As4.GetComponent<Note_Mine>().noteName = "A#";

        // Octave 5
        C5 = pianoListRef.PianoKeys[36];
        C5.GetComponent<Note_Mine>().noteName = "C";
        D5 = pianoListRef.PianoKeys[37];
        D5.GetComponent<Note_Mine>().noteName = "D";
        E5 = pianoListRef.PianoKeys[38];
        E5.GetComponent<Note_Mine>().noteName = "E";
        F5 = pianoListRef.PianoKeys[39];
        F5.GetComponent<Note_Mine>().noteName = "F";
        G5 = pianoListRef.PianoKeys[40];
        G5.GetComponent<Note_Mine>().noteName = "G";
        A5 = pianoListRef.PianoKeys[41];
        A5.GetComponent<Note_Mine>().noteName = "A";
        B5 = pianoListRef.PianoKeys[42];
        B5.GetComponent<Note_Mine>().noteName = "B";
        Cs5 = pianoListRef.PianoKeys[43];
        Cs5.GetComponent<Note_Mine>().noteName = "C#";
        Ds5 = pianoListRef.PianoKeys[44];
        Ds5.GetComponent<Note_Mine>().noteName = "D#";
        Fs5 = pianoListRef.PianoKeys[45];
        Fs5.GetComponent<Note_Mine>().noteName = "F#";
        Gs5 = pianoListRef.PianoKeys[46];
        Gs5.GetComponent<Note_Mine>().noteName = "G#";
        As5 = pianoListRef.PianoKeys[47];
        As5.GetComponent<Note_Mine>().noteName = "A#";

        // Octave 6
        C6 = pianoListRef.PianoKeys[48];
        C6.GetComponent<Note_Mine>().noteName = "C";
        D6 = pianoListRef.PianoKeys[49];
        D6.GetComponent<Note_Mine>().noteName = "D";
        E6 = pianoListRef.PianoKeys[50];
        E6.GetComponent<Note_Mine>().noteName = "E";
        F6 = pianoListRef.PianoKeys[51];
        F6.GetComponent<Note_Mine>().noteName = "F";
        G6 = pianoListRef.PianoKeys[52];
        G6.GetComponent<Note_Mine>().noteName = "G";
        A6 = pianoListRef.PianoKeys[53];
        A6.GetComponent<Note_Mine>().noteName = "A";
        B6 = pianoListRef.PianoKeys[54];
        B6.GetComponent<Note_Mine>().noteName = "B";
        Cs6 = pianoListRef.PianoKeys[55];
        Cs6.GetComponent<Note_Mine>().noteName = "C#";
        Ds6 = pianoListRef.PianoKeys[56];
        Ds6.GetComponent<Note_Mine>().noteName = "D#";
        Fs6 = pianoListRef.PianoKeys[57];
        Fs6.GetComponent<Note_Mine>().noteName = "F#";
        Gs6 = pianoListRef.PianoKeys[58];
        Gs6.GetComponent<Note_Mine>().noteName = "G#";
        As6 = pianoListRef.PianoKeys[59];
        As6.GetComponent<Note_Mine>().noteName = "A#";
    }
}
