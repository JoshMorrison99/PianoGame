using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PianoNoteSpawner : MonoBehaviour
{

    public GameObject QuarterNote;
    public GameObject HalfNote;
    public GameObject Dotted_QuarterNote;
    public GameObject EighthNote;
    public GameObject WholeNote;

    public GameObject spawnNoteSharpObject;

    public PianoKeyPresses pianoListRef;

    public List<GameObject> spawnedNotes;
    public List<GameObject> garbageNotes;

    const float NOTE_DESTROY_DEPTH = -10f;

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

    public void spawnNote(string type, GameObject note, bool isSharp)
    {
        if (type == "HalfNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(HalfNote.transform.localScale.x * 1.3f, HalfNote.transform.localScale.y * 1.3f, 0);
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
            }
        } else if(type == "QuarterNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(QuarterNote.transform.localScale.x * 1.3f, QuarterNote.transform.localScale.y * 1.3f, 0);
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
            }
        }else if (type == "DottedQuartedNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(Dotted_QuarterNote.transform.localScale.x * 1.3f, Dotted_QuarterNote.transform.localScale.y * 1.3f, 0);
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
            }
        }
        else if (type == "EighthNote")
        {
            if (isSharp)
            {
                GameObject spawnedNote = Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 10f, note.transform.position.z + 2), Quaternion.identity);
                spawnedNote.GetComponentInChildren<TextMeshPro>().text = note.GetComponent<Note>().noteName;
                spawnedNote.GetComponentInChildren<TextMeshPro>().transform.localPosition = new Vector3(2.1f, -1, 0);
                spawnedNotes.Add(spawnedNote);

                if (PersistentData.data.selectedSong == 1)
                {
                    // Scale Note Prefabs
                    spawnedNote.transform.localScale = new Vector3(EighthNote.transform.localScale.x * 1.3f, EighthNote.transform.localScale.y * 1.3f, 0);
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
            }
        }
        
    }

    public void setupUI()
    {
        // Octave 2
        C2 = pianoListRef.PianoKeys[0];
        C2.GetComponent<Note>().noteName = "C";
        D2 = pianoListRef.PianoKeys[1];
        D2.GetComponent<Note>().noteName = "D";
        E2 = pianoListRef.PianoKeys[2];
        E2.GetComponent<Note>().noteName = "E";
        F2 = pianoListRef.PianoKeys[3];
        F2.GetComponent<Note>().noteName = "F";
        G2 = pianoListRef.PianoKeys[4];
        G2.GetComponent<Note>().noteName = "G";
        A2 = pianoListRef.PianoKeys[5];
        A2.GetComponent<Note>().noteName = "A";
        B2 = pianoListRef.PianoKeys[6];
        B2.GetComponent<Note>().noteName = "B";
        Cs2 = pianoListRef.PianoKeys[7];
        Cs2.GetComponent<Note>().noteName = "C#";
        Ds2 = pianoListRef.PianoKeys[8];
        Ds2.GetComponent<Note>().noteName = "D#";
        Fs2 = pianoListRef.PianoKeys[9];
        Fs2.GetComponent<Note>().noteName = "F#";
        Gs2 = pianoListRef.PianoKeys[10];
        Gs2.GetComponent<Note>().noteName = "G#";
        As2 = pianoListRef.PianoKeys[11];
        As2.GetComponent<Note>().noteName = "A#";

        // Octave 3
        C3 = pianoListRef.PianoKeys[12];
        C3.GetComponent<Note>().noteName = "C";
        D3 = pianoListRef.PianoKeys[13];
        D3.GetComponent<Note>().noteName = "D";
        E3 = pianoListRef.PianoKeys[14];
        E3.GetComponent<Note>().noteName = "E";
        F3 = pianoListRef.PianoKeys[15];
        F3.GetComponent<Note>().noteName = "F";
        G3 = pianoListRef.PianoKeys[16];
        G3.GetComponent<Note>().noteName = "G";
        A3 = pianoListRef.PianoKeys[17];
        A3.GetComponent<Note>().noteName = "A";
        B3 = pianoListRef.PianoKeys[18];
        B3.GetComponent<Note>().noteName = "B";
        Cs3 = pianoListRef.PianoKeys[19];
        Cs3.GetComponent<Note>().noteName = "C#";
        Ds3 = pianoListRef.PianoKeys[20];
        Ds3.GetComponent<Note>().noteName = "D#";
        Fs3 = pianoListRef.PianoKeys[21];
        Fs3.GetComponent<Note>().noteName = "F#";
        Gs3 = pianoListRef.PianoKeys[22];
        Gs3.GetComponent<Note>().noteName = "G#";
        As3 = pianoListRef.PianoKeys[23];
        As3.GetComponent<Note>().noteName = "A#";

        // Octave 4
        C4 = pianoListRef.PianoKeys[24];
        C4.GetComponent<Note>().noteName = "C";
        D4 = pianoListRef.PianoKeys[25];
        D4.GetComponent<Note>().noteName = "D";
        E4 = pianoListRef.PianoKeys[26];
        E4.GetComponent<Note>().noteName = "E";
        F4 = pianoListRef.PianoKeys[27];
        F4.GetComponent<Note>().noteName = "F";
        G4 = pianoListRef.PianoKeys[28];
        G4.GetComponent<Note>().noteName = "G";
        A4 = pianoListRef.PianoKeys[29];
        A4.GetComponent<Note>().noteName = "A";
        B4 = pianoListRef.PianoKeys[30];
        B4.GetComponent<Note>().noteName = "B";
        Cs4 = pianoListRef.PianoKeys[31];
        Cs4.GetComponent<Note>().noteName = "C#";
        Ds4 = pianoListRef.PianoKeys[32];
        Ds4.GetComponent<Note>().noteName = "D#";
        Fs4 = pianoListRef.PianoKeys[33];
        Fs4.GetComponent<Note>().noteName = "F#";
        Gs4 = pianoListRef.PianoKeys[34];
        Gs4.GetComponent<Note>().noteName = "G#";
        As4 = pianoListRef.PianoKeys[35];
        As4.GetComponent<Note>().noteName = "A#";

        // Octave 5
        C5 = pianoListRef.PianoKeys[36];
        C5.GetComponent<Note>().noteName = "C";
        D5 = pianoListRef.PianoKeys[37];
        D5.GetComponent<Note>().noteName = "D";
        E5 = pianoListRef.PianoKeys[38];
        E5.GetComponent<Note>().noteName = "E";
        F5 = pianoListRef.PianoKeys[39];
        F5.GetComponent<Note>().noteName = "F";
        G5 = pianoListRef.PianoKeys[40];
        G5.GetComponent<Note>().noteName = "G";
        A5 = pianoListRef.PianoKeys[41];
        A5.GetComponent<Note>().noteName = "A";
        B5 = pianoListRef.PianoKeys[42];
        B5.GetComponent<Note>().noteName = "B";
        Cs5 = pianoListRef.PianoKeys[43];
        Cs5.GetComponent<Note>().noteName = "C#";
        Ds5 = pianoListRef.PianoKeys[44];
        Ds5.GetComponent<Note>().noteName = "D#";
        Fs5 = pianoListRef.PianoKeys[45];
        Fs5.GetComponent<Note>().noteName = "F#";
        Gs5 = pianoListRef.PianoKeys[46];
        Gs5.GetComponent<Note>().noteName = "G#";
        As5 = pianoListRef.PianoKeys[47];
        As5.GetComponent<Note>().noteName = "A#";

        // Octave 6
        C6 = pianoListRef.PianoKeys[48];
        C6.GetComponent<Note>().noteName = "C";
        D6 = pianoListRef.PianoKeys[49];
        D6.GetComponent<Note>().noteName = "D";
        E6 = pianoListRef.PianoKeys[50];
        E6.GetComponent<Note>().noteName = "E";
        F6 = pianoListRef.PianoKeys[51];
        F6.GetComponent<Note>().noteName = "F";
        G6 = pianoListRef.PianoKeys[52];
        G6.GetComponent<Note>().noteName = "G";
        A6 = pianoListRef.PianoKeys[53];
        A6.GetComponent<Note>().noteName = "A";
        B6 = pianoListRef.PianoKeys[54];
        B6.GetComponent<Note>().noteName = "B";
        Cs6 = pianoListRef.PianoKeys[55];
        Cs6.GetComponent<Note>().noteName = "C#";
        Ds6 = pianoListRef.PianoKeys[56];
        Ds6.GetComponent<Note>().noteName = "D#";
        Fs6 = pianoListRef.PianoKeys[57];
        Fs6.GetComponent<Note>().noteName = "F#";
        Gs6 = pianoListRef.PianoKeys[58];
        Gs6.GetComponent<Note>().noteName = "G#";
        As6 = pianoListRef.PianoKeys[59];
        As6.GetComponent<Note>().noteName = "A#";
    }
}
