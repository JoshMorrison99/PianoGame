using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoNoteSpawner : MonoBehaviour
{

    public GameObject spawnNoteObject;
    public GameObject spawnNoteSharpObject;

    public PianoUI pianoListRef;

    public List<GameObject> spawnedNotes;
    public List<GameObject> garbageNotes;

    float noteSpeed = 0.005f;

    // Piano Notes
    GameObject C2;
    GameObject D2;
    GameObject E2;
    GameObject F2;
    GameObject G2;
    GameObject A2;
    GameObject B2;
    GameObject Cs2;
    GameObject Ds2;
    GameObject Fs2;
    GameObject Gs2;
    GameObject As2;

    GameObject C3;
    GameObject D3;
    GameObject E3;
    GameObject F3;
    GameObject G3;
    GameObject A3;
    GameObject B3;
    GameObject Cs3;
    GameObject Ds3;
    GameObject Fs3;
    GameObject Gs3;
    GameObject As3;

    GameObject C4;
    GameObject D4;
    GameObject E4;
    GameObject F4;
    GameObject G4;
    GameObject A4;
    GameObject B4;
    GameObject Cs4;
    GameObject Ds4;
    GameObject Fs4;
    GameObject Gs4;
    GameObject As4;

    GameObject C5;
    GameObject D5;
    GameObject E5;
    GameObject F5;
    GameObject G5;
    GameObject A5;
    GameObject B5;
    GameObject Cs5;
    GameObject Ds5;
    GameObject Fs5;
    GameObject Gs5;
    GameObject As5;

    GameObject C6;
    GameObject D6;
    GameObject E6;
    GameObject F6;
    GameObject G6;
    GameObject A6;
    GameObject B6;
    GameObject Cs6;
    GameObject Ds6;
    GameObject Fs6;
    GameObject Gs6;
    GameObject As6;


    private void Start()
    {
        setupUI();
        spawnNote(1, C2, false);
        spawnNote(1, F2, false);
        spawnNote(1, C3, false);
        spawnNote(1, F3, false);
    }

    private void Update()
    {
        if (spawnedNotes.Count > 0)
        {
            for (int i = 0; i < spawnedNotes.Count; i++)
            {
                if (spawnedNotes[i].transform.position.y > -5)
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
        }else
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

    public void spawnNote(float noteDuration, GameObject note, bool isSharp)
    {
        if (isSharp)
        {
            spawnedNotes.Add(Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 8.55f, note.transform.position.z), Quaternion.identity));
        }
        else
        {
            spawnedNotes.Add(Instantiate(spawnNoteObject, new Vector3(note.transform.position.x, note.transform.position.y + 9, note.transform.position.z), Quaternion.identity));
        }
    }

    public void setupUI()
    {
        // Octave 2
        C2 = pianoListRef.PianoKeys[0];
        D2 = pianoListRef.PianoKeys[1];
        E2 = pianoListRef.PianoKeys[2];
        F2 = pianoListRef.PianoKeys[3];
        G2 = pianoListRef.PianoKeys[4];
        A2 = pianoListRef.PianoKeys[5];
        B2 = pianoListRef.PianoKeys[6];
        Cs2 = pianoListRef.PianoKeys[7];
        Ds2 = pianoListRef.PianoKeys[8];
        Fs2 = pianoListRef.PianoKeys[9];
        Gs2 = pianoListRef.PianoKeys[10];
        As2 = pianoListRef.PianoKeys[11];

        // Octave 3
        C3 = pianoListRef.PianoKeys[12];
        D3 = pianoListRef.PianoKeys[13];
        E3 = pianoListRef.PianoKeys[14];
        F3 = pianoListRef.PianoKeys[15];
        G3 = pianoListRef.PianoKeys[16];
        A3 = pianoListRef.PianoKeys[17];
        B3 = pianoListRef.PianoKeys[18];
        Cs3 = pianoListRef.PianoKeys[19];
        Ds3 = pianoListRef.PianoKeys[20];
        Fs3 = pianoListRef.PianoKeys[21];
        Gs3 = pianoListRef.PianoKeys[22];
        As3 = pianoListRef.PianoKeys[23];

        // Octave 4
        C4 = pianoListRef.PianoKeys[24];
        D4 = pianoListRef.PianoKeys[25];
        E4 = pianoListRef.PianoKeys[26];
        F4 = pianoListRef.PianoKeys[27];
        G4 = pianoListRef.PianoKeys[28];
        A4 = pianoListRef.PianoKeys[29];
        B4 = pianoListRef.PianoKeys[30];
        Cs4 = pianoListRef.PianoKeys[31];
        Ds4 = pianoListRef.PianoKeys[32];
        Fs4 = pianoListRef.PianoKeys[33];
        Gs4 = pianoListRef.PianoKeys[34];
        As4 = pianoListRef.PianoKeys[35];

        // Octave 5
        C5 = pianoListRef.PianoKeys[36];
        D5 = pianoListRef.PianoKeys[37];
        E5 = pianoListRef.PianoKeys[38];
        F5 = pianoListRef.PianoKeys[39];
        G5 = pianoListRef.PianoKeys[40];
        A5 = pianoListRef.PianoKeys[41];
        B5 = pianoListRef.PianoKeys[42];
        Cs5 = pianoListRef.PianoKeys[43];
        Ds5 = pianoListRef.PianoKeys[44];
        Fs5 = pianoListRef.PianoKeys[45];
        Gs5 = pianoListRef.PianoKeys[46];
        As5 = pianoListRef.PianoKeys[47];

        // Octave 6
        C6 = pianoListRef.PianoKeys[48];
        D6 = pianoListRef.PianoKeys[49];
        E6 = pianoListRef.PianoKeys[50];
        F6 = pianoListRef.PianoKeys[51];
        G6 = pianoListRef.PianoKeys[52];
        A6 = pianoListRef.PianoKeys[53];
        B6 = pianoListRef.PianoKeys[54];
        Cs6 = pianoListRef.PianoKeys[55];
        Ds6 = pianoListRef.PianoKeys[56];
        Fs6 = pianoListRef.PianoKeys[57];
        Gs6 = pianoListRef.PianoKeys[58];
        As6 = pianoListRef.PianoKeys[59];
    }
}
