using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Devices;
using UnityEngine.InputSystem;

public class PianoNoteSpawner : MonoBehaviour
{

    public GameObject SharpNote;
    public GameObject Note;

    public PianoKeyPresses pianoListRef;

    public List<GameObject> spawnedNotes;
    public List<GameObject> garbageNotes;
    public List<GameObject> garbageNotesSharp;

    const float NOTE_DESTROY_DEPTH = -20f;

    const float SEE_YOU_AGAIN_NOTESCALE = 2f;

    const float NOTE_SCALE = 2.4f;

    public bool isNoteLabelled = true;

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

    int uid;

    float noteHeight = 10f;
    float noteSharpHeight = 9.55f;

    private void Start()
    {
        uid = 0;
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
                if (spawnedNotes[i].transform.GetChild(0).GetComponent<Note_Falling>().noteName.Contains("#"))
                {
                    garbageNotesSharp.Add(spawnedNotes[i]);
                }
                else
                {
                    garbageNotes.Add(spawnedNotes[i]);
                }
                
                spawnedNotes.RemoveAt(i);
                i--;
            }
        }


        // CLEAR THIS AT THE END OF THE SONG
        /*if (garbageNotes.Count > 0)
        {
            garbageCollect();
        }*/



    }

    public void garbageCollect()
    {
        foreach (GameObject each in garbageNotes)
        {
            Destroy(each);
        }
    }


    public void spawnNote(object sender, NotesEventArgs notesArgs)
    {
        var notesList = notesArgs.Notes;

        foreach (Note item in notesList)
        {
            string noteName = item.ToString();
           
            TempoMap tempoMap = PersistentData.data.myMidi.GetTempoMap();
            MetricTimeSpan metricLength = item.LengthAs<MetricTimeSpan>(tempoMap);

            float duration = (float)metricLength.Seconds + ((float)metricLength.Milliseconds) / 1000;


            //Debug.Log(duration);
            if (noteName == "C2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(C2.transform.position.x, C2.transform.position.y + noteHeight, C2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(C2.transform.position.x, C2.transform.position.y + noteHeight, C2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
            }
            else if (noteName == "C#2")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Cs2.transform.position.x, Cs2.transform.position.y + noteSharpHeight, Cs2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs2.transform.position.x, Cs2.transform.position.y + noteSharpHeight, Cs2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }

                
            }
            else if (noteName == "D2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(D2.transform.position.x, D2.transform.position.y + noteHeight, D2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(D2.transform.position.x, D2.transform.position.y + noteHeight, D2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D#2")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Ds2.transform.position.x, Ds2.transform.position.y + noteSharpHeight, Ds2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds2.transform.position.x, Ds2.transform.position.y + noteSharpHeight, Ds2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "E2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(E2.transform.position.x, E2.transform.position.y + noteHeight, E2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(E2.transform.position.x, E2.transform.position.y + noteHeight, E2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(F2.transform.position.x, F2.transform.position.y + noteHeight, F2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(F2.transform.position.x, F2.transform.position.y + noteHeight, F2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F#2")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Fs2.transform.position.x, Fs2.transform.position.y + noteSharpHeight, Fs2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs2.transform.position.x, Fs2.transform.position.y + noteSharpHeight, Fs2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(G2.transform.position.x, G2.transform.position.y + noteHeight, G2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(G2.transform.position.x, G2.transform.position.y + noteHeight, G2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G#2")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Gs2.transform.position.x, Gs2.transform.position.y + noteSharpHeight, Gs2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs2.transform.position.x, Gs2.transform.position.y + noteSharpHeight, Gs2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(A2.transform.position.x, A2.transform.position.y + noteHeight, A2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(A2.transform.position.x, A2.transform.position.y + noteHeight, A2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A#2")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(As2.transform.position.x, As2.transform.position.y + noteSharpHeight, As2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As2.transform.position.x, As2.transform.position.y + noteSharpHeight, As2.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "B2")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(B2.transform.position.x, B2.transform.position.y + noteHeight, B2.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(B2.transform.position.x, B2.transform.position.y + noteHeight, B2.transform.position.z), Quaternion.identity);
                    // spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(C3.transform.position.x, C3.transform.position.y + noteHeight, C3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(C3.transform.position.x, C3.transform.position.y + noteHeight, C3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C#3")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Cs3.transform.position.x, Cs3.transform.position.y + noteSharpHeight, Cs3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs3.transform.position.x, Cs3.transform.position.y + noteSharpHeight, Cs3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(D3.transform.position.x, D3.transform.position.y + noteHeight, D3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(D3.transform.position.x, D3.transform.position.y + noteHeight, D3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D#3")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Ds3.transform.position.x, Ds3.transform.position.y + noteSharpHeight, Ds3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds3.transform.position.x, Ds3.transform.position.y + noteSharpHeight, Ds3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "E3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(E3.transform.position.x, E3.transform.position.y + noteHeight, E3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(E3.transform.position.x, E3.transform.position.y + noteHeight, E3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(F3.transform.position.x, F3.transform.position.y + noteHeight, F3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(F3.transform.position.x, F3.transform.position.y + noteHeight, F3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F#3")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Fs3.transform.position.x, Fs3.transform.position.y + noteSharpHeight, Fs3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs3.transform.position.x, Fs3.transform.position.y + noteSharpHeight, Fs3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(G3.transform.position.x, G3.transform.position.y + noteHeight, G3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(G3.transform.position.x, G3.transform.position.y + noteHeight, G3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G#3")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Gs3.transform.position.x, Gs3.transform.position.y + noteSharpHeight, Gs3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs3.transform.position.x, Gs3.transform.position.y + noteSharpHeight, Gs3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(A3.transform.position.x, A3.transform.position.y + noteHeight, A3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(A3.transform.position.x, A3.transform.position.y + noteHeight, A3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A#3")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(As3.transform.position.x, As3.transform.position.y + noteSharpHeight, As3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As3.transform.position.x, As3.transform.position.y + noteSharpHeight, As3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "B3")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(B3.transform.position.x, B3.transform.position.y + noteHeight, B3.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(B3.transform.position.x, B3.transform.position.y + noteHeight, B3.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(C4.transform.position.x, C4.transform.position.y + noteHeight, C4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(C4.transform.position.x, C4.transform.position.y + noteHeight, C4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C#4")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Cs4.transform.position.x, Cs4.transform.position.y + noteSharpHeight, Cs4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs4.transform.position.x, Cs4.transform.position.y + noteSharpHeight, Cs4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(D4.transform.position.x, D4.transform.position.y + noteHeight, D4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(D4.transform.position.x, D4.transform.position.y + noteHeight, D4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D#4")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Ds4.transform.position.x, Ds4.transform.position.y + noteSharpHeight, Ds4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds4.transform.position.x, Ds4.transform.position.y + noteSharpHeight, Ds4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "E4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(E4.transform.position.x, E4.transform.position.y + noteHeight, E4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(E4.transform.position.x, E4.transform.position.y + noteHeight, E4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(F4.transform.position.x, F4.transform.position.y + noteHeight, F4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(F4.transform.position.x, F4.transform.position.y + noteHeight, F4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F#4")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Fs4.transform.position.x, Fs4.transform.position.y + noteSharpHeight, Fs4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs4.transform.position.x, Fs4.transform.position.y + noteSharpHeight, Fs4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(G4.transform.position.x, G4.transform.position.y + noteHeight, G4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(G4.transform.position.x, G4.transform.position.y + noteHeight, G4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G#4")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Gs4.transform.position.x, Gs4.transform.position.y + noteSharpHeight, Gs4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs4.transform.position.x, Gs4.transform.position.y + noteSharpHeight, Gs4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(A4.transform.position.x, A4.transform.position.y + noteHeight, A4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(A4.transform.position.x, A4.transform.position.y + noteHeight, A4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A#4")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(As4.transform.position.x, As4.transform.position.y + noteSharpHeight, As4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As4.transform.position.x, As4.transform.position.y + noteSharpHeight, As4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "B4")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(B4.transform.position.x, B4.transform.position.y + noteHeight, B4.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(B4.transform.position.x, B4.transform.position.y + noteHeight, B4.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(C5.transform.position.x, C5.transform.position.y + noteHeight, C5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(C5.transform.position.x, C5.transform.position.y + noteHeight, C5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C#5")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Cs5.transform.position.x, Cs5.transform.position.y + noteSharpHeight, Cs5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs5.transform.position.x, Cs5.transform.position.y + noteSharpHeight, Cs5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(D5.transform.position.x, D5.transform.position.y + noteHeight, D5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(D5.transform.position.x, D5.transform.position.y + noteHeight, D5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D#5")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Ds5.transform.position.x, Ds5.transform.position.y + noteSharpHeight, Ds5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds5.transform.position.x, Ds5.transform.position.y + noteSharpHeight, Ds5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "E5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(E5.transform.position.x, E5.transform.position.y + noteHeight, E5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(E5.transform.position.x, E5.transform.position.y + noteHeight, E5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(F5.transform.position.x, F5.transform.position.y + noteHeight, F5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(F5.transform.position.x, F5.transform.position.y + noteHeight, F5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F#5")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Fs5.transform.position.x, Fs5.transform.position.y + noteSharpHeight, Fs5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs5.transform.position.x, Fs5.transform.position.y + noteSharpHeight, Fs5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(G5.transform.position.x, G5.transform.position.y + noteHeight, G5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(G5.transform.position.x, G5.transform.position.y + noteHeight, G5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G#5")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Gs5.transform.position.x, Gs5.transform.position.y + noteSharpHeight, Gs5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs5.transform.position.x, Gs5.transform.position.y + noteSharpHeight, Gs5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(A5.transform.position.x, A5.transform.position.y + noteHeight, A5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(A5.transform.position.x, A5.transform.position.y + noteHeight, A5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A#5")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(As5.transform.position.x, As5.transform.position.y + noteSharpHeight, As5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As5.transform.position.x, As5.transform.position.y + noteSharpHeight, As5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "B5")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(B5.transform.position.x, B5.transform.position.y + noteHeight, B5.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(B5.transform.position.x, B5.transform.position.y + noteHeight, B5.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(C6.transform.position.x, C6.transform.position.y + noteHeight, C6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(C6.transform.position.x, C6.transform.position.y + noteHeight, C6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "C#6")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Cs6.transform.position.x, Cs6.transform.position.y + noteSharpHeight, Cs6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Cs6.transform.position.x, Cs6.transform.position.y + noteSharpHeight, Cs6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "C#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(D6.transform.position.x, D6.transform.position.y + noteHeight, D6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(D6.transform.position.x, D6.transform.position.y + noteHeight, D6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "D#6")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Ds6.transform.position.x, Ds6.transform.position.y + noteSharpHeight, Ds6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Ds6.transform.position.x, Ds6.transform.position.y + noteSharpHeight, Ds6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "D#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "E6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(E6.transform.position.x, E6.transform.position.y + noteHeight, E6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(E6.transform.position.x, E6.transform.position.y + noteHeight, E6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "E#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(F6.transform.position.x, F6.transform.position.y + noteHeight, F6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(F6.transform.position.x, F6.transform.position.y + noteHeight, F6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "F#6")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Fs6.transform.position.x, Fs6.transform.position.y + noteSharpHeight, Fs6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Fs6.transform.position.x, Fs6.transform.position.y + noteSharpHeight, Fs6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "F#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(G6.transform.position.x, G6.transform.position.y + noteHeight, G6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(G6.transform.position.x, G6.transform.position.y + noteHeight, G6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "G#6")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(Gs6.transform.position.x, Gs6.transform.position.y + noteSharpHeight, Gs6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(Gs6.transform.position.x, Gs6.transform.position.y + noteSharpHeight, Gs6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "G#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(A6.transform.position.x, A6.transform.position.y + noteHeight, A6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(A6.transform.position.x, A6.transform.position.y + noteHeight, A6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "A#6")
            {
                if (garbageNotesSharp.Count > 0)
                {
                    GameObject spawnedNote = garbageNotesSharp[0];
                    garbageNotesSharp.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(As6.transform.position.x, As6.transform.position.y + noteSharpHeight, As6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(SharpNote, new Vector3(As6.transform.position.x, As6.transform.position.y + noteSharpHeight, As6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "A#" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }
            else if (noteName == "B6")
            {
                if (garbageNotes.Count > 0)
                {
                    GameObject spawnedNote = garbageNotes[0];
                    garbageNotes.RemoveAt(0);
                    spawnedNote.transform.position = new Vector3(B6.transform.position.x, B6.transform.position.y + noteHeight, B6.transform.position.z);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                else
                {
                    GameObject spawnedNote = Instantiate(Note, new Vector3(B6.transform.position.x, B6.transform.position.y + noteHeight, B6.transform.position.z), Quaternion.identity);
                    //spawnedNote.transform.GetChild(0).localScale = new Vector3(spawnedNote.transform.GetChild(0).localScale.x, spawnedNote.transform.GetChild(0).localScale.y * duration, 0);
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().uid = uid + 1;
                    spawnedNote.transform.GetChild(0).GetComponent<Note_Falling>().noteName = noteName;
                    spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = isNoteLabelled ? spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "B" : spawnedNote.transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "";
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>().size = new Vector2(spawnedNote.transform.GetChild(0).localScale.x, NOTE_SCALE * duration);
                    spawnedNote.transform.position = new Vector3(spawnedNote.transform.position.x, spawnedNote.transform.position.y + (NOTE_SCALE * duration / 2), 0);
                    spawnedNotes.Add(spawnedNote);
                }
                
            }

            uid += 1;
        }

    }

    public void setupUI()
    {
        // Octave 2
        C2 = pianoListRef.PianoKeys[0];
        C2.GetComponent<Note_Mine>().noteName = "C2";
        D2 = pianoListRef.PianoKeys[1];
        D2.GetComponent<Note_Mine>().noteName = "D2";
        E2 = pianoListRef.PianoKeys[2];
        E2.GetComponent<Note_Mine>().noteName = "E2";
        F2 = pianoListRef.PianoKeys[3];
        F2.GetComponent<Note_Mine>().noteName = "F2";
        G2 = pianoListRef.PianoKeys[4];
        G2.GetComponent<Note_Mine>().noteName = "G2";
        A2 = pianoListRef.PianoKeys[5];
        A2.GetComponent<Note_Mine>().noteName = "A2";
        B2 = pianoListRef.PianoKeys[6];
        B2.GetComponent<Note_Mine>().noteName = "B2";
        Cs2 = pianoListRef.PianoKeys[7];
        Cs2.GetComponent<Note_Mine>().noteName = "C#2";
        Ds2 = pianoListRef.PianoKeys[8];
        Ds2.GetComponent<Note_Mine>().noteName = "D#2";
        Fs2 = pianoListRef.PianoKeys[9];
        Fs2.GetComponent<Note_Mine>().noteName = "F#2";
        Gs2 = pianoListRef.PianoKeys[10];
        Gs2.GetComponent<Note_Mine>().noteName = "G#2";
        As2 = pianoListRef.PianoKeys[11];
        As2.GetComponent<Note_Mine>().noteName = "A#2";

        // Octave 3
        C3 = pianoListRef.PianoKeys[12];
        C3.GetComponent<Note_Mine>().noteName = "C3";
        D3 = pianoListRef.PianoKeys[13];
        D3.GetComponent<Note_Mine>().noteName = "D3";
        E3 = pianoListRef.PianoKeys[14];
        E3.GetComponent<Note_Mine>().noteName = "E3";
        F3 = pianoListRef.PianoKeys[15];
        F3.GetComponent<Note_Mine>().noteName = "F3";
        G3 = pianoListRef.PianoKeys[16];
        G3.GetComponent<Note_Mine>().noteName = "G3";
        A3 = pianoListRef.PianoKeys[17];
        A3.GetComponent<Note_Mine>().noteName = "A3";
        B3 = pianoListRef.PianoKeys[18];
        B3.GetComponent<Note_Mine>().noteName = "B3";
        Cs3 = pianoListRef.PianoKeys[19];
        Cs3.GetComponent<Note_Mine>().noteName = "C#3";
        Ds3 = pianoListRef.PianoKeys[20];
        Ds3.GetComponent<Note_Mine>().noteName = "D#3";
        Fs3 = pianoListRef.PianoKeys[21];
        Fs3.GetComponent<Note_Mine>().noteName = "F#3";
        Gs3 = pianoListRef.PianoKeys[22];
        Gs3.GetComponent<Note_Mine>().noteName = "G#3";
        As3 = pianoListRef.PianoKeys[23];
        As3.GetComponent<Note_Mine>().noteName = "A#3";

        // Octave 4
        C4 = pianoListRef.PianoKeys[24];
        C4.GetComponent<Note_Mine>().noteName = "C4";
        D4 = pianoListRef.PianoKeys[25];
        D4.GetComponent<Note_Mine>().noteName = "D4";
        E4 = pianoListRef.PianoKeys[26];
        E4.GetComponent<Note_Mine>().noteName = "E4";
        F4 = pianoListRef.PianoKeys[27];
        F4.GetComponent<Note_Mine>().noteName = "F4";
        G4 = pianoListRef.PianoKeys[28];
        G4.GetComponent<Note_Mine>().noteName = "G4";
        A4 = pianoListRef.PianoKeys[29];
        A4.GetComponent<Note_Mine>().noteName = "A4";
        B4 = pianoListRef.PianoKeys[30];
        B4.GetComponent<Note_Mine>().noteName = "B4";
        Cs4 = pianoListRef.PianoKeys[31];
        Cs4.GetComponent<Note_Mine>().noteName = "C#4";
        Ds4 = pianoListRef.PianoKeys[32];
        Ds4.GetComponent<Note_Mine>().noteName = "D#4";
        Fs4 = pianoListRef.PianoKeys[33];
        Fs4.GetComponent<Note_Mine>().noteName = "F#4";
        Gs4 = pianoListRef.PianoKeys[34];
        Gs4.GetComponent<Note_Mine>().noteName = "G#4";
        As4 = pianoListRef.PianoKeys[35];
        As4.GetComponent<Note_Mine>().noteName = "A#4";

        // Octave 5
        C5 = pianoListRef.PianoKeys[36];
        C5.GetComponent<Note_Mine>().noteName = "C5";
        D5 = pianoListRef.PianoKeys[37];
        D5.GetComponent<Note_Mine>().noteName = "D5";
        E5 = pianoListRef.PianoKeys[38];
        E5.GetComponent<Note_Mine>().noteName = "E5";
        F5 = pianoListRef.PianoKeys[39];
        F5.GetComponent<Note_Mine>().noteName = "F5";
        G5 = pianoListRef.PianoKeys[40];
        G5.GetComponent<Note_Mine>().noteName = "G5";
        A5 = pianoListRef.PianoKeys[41];
        A5.GetComponent<Note_Mine>().noteName = "A5";
        B5 = pianoListRef.PianoKeys[42];
        B5.GetComponent<Note_Mine>().noteName = "B5";
        Cs5 = pianoListRef.PianoKeys[43];
        Cs5.GetComponent<Note_Mine>().noteName = "C#5";
        Ds5 = pianoListRef.PianoKeys[44];
        Ds5.GetComponent<Note_Mine>().noteName = "D#5";
        Fs5 = pianoListRef.PianoKeys[45];
        Fs5.GetComponent<Note_Mine>().noteName = "F#5";
        Gs5 = pianoListRef.PianoKeys[46];
        Gs5.GetComponent<Note_Mine>().noteName = "G#5";
        As5 = pianoListRef.PianoKeys[47];
        As5.GetComponent<Note_Mine>().noteName = "A#5";

        // Octave 6
        C6 = pianoListRef.PianoKeys[48];
        C6.GetComponent<Note_Mine>().noteName = "C6";
        D6 = pianoListRef.PianoKeys[49];
        D6.GetComponent<Note_Mine>().noteName = "D6";
        E6 = pianoListRef.PianoKeys[50];
        E6.GetComponent<Note_Mine>().noteName = "E6";
        F6 = pianoListRef.PianoKeys[51];
        F6.GetComponent<Note_Mine>().noteName = "F6";
        G6 = pianoListRef.PianoKeys[52];
        G6.GetComponent<Note_Mine>().noteName = "G6";
        A6 = pianoListRef.PianoKeys[53];
        A6.GetComponent<Note_Mine>().noteName = "A6";
        B6 = pianoListRef.PianoKeys[54];
        B6.GetComponent<Note_Mine>().noteName = "B6";
        Cs6 = pianoListRef.PianoKeys[55];
        Cs6.GetComponent<Note_Mine>().noteName = "C#6";
        Ds6 = pianoListRef.PianoKeys[56];
        Ds6.GetComponent<Note_Mine>().noteName = "D#6";
        Fs6 = pianoListRef.PianoKeys[57];
        Fs6.GetComponent<Note_Mine>().noteName = "F#6";
        Gs6 = pianoListRef.PianoKeys[58];
        Gs6.GetComponent<Note_Mine>().noteName = "G#6";
        As6 = pianoListRef.PianoKeys[59];
        As6.GetComponent<Note_Mine>().noteName = "A#6";
    }
}
