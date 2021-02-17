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

    const float NOTE_WIDTH = 0.45f;
    const float NOTE_SHARP_WIDTH = 0.3f;

    float noteSpeed = 0.0075f;

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

    private float TicksPerSecond = 1.5f;

    private float _t;
    private int counter = 0;


    private void Start()
    {
        setupUI();
    }

    
    void OnEnable()
    {
        _t = 0f;
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

        // Begin Song
        float dur = 1f / this.TicksPerSecond;
        _t += Time.deltaTime;
        int cnt = 4;
        while (_t > dur && cnt > 0)
        {
            counter++;
            _t -= dur;
            cnt--;
            AlanWalker_Faded(counter);
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
            GameObject spawnedNote = Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 8.55f, note.transform.position.z), Quaternion.identity);
            spawnedNote.gameObject.transform.localScale = new Vector3(NOTE_SHARP_WIDTH, noteDuration, spawnedNote.gameObject.transform.localScale.z);
            spawnedNotes.Add(spawnedNote);
        }
        else
        {
            GameObject spawnedNote = Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 8.55f, note.transform.position.z), Quaternion.identity);
            spawnedNote.gameObject.transform.localScale = new Vector3(NOTE_WIDTH, noteDuration, spawnedNote.gameObject.transform.localScale.z);
            spawnedNotes.Add(spawnedNote);
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

    public void AlanWalker_Faded(int counter)
    {
        switch (counter)
        {
            case 1:
                spawnNote(1f, G4, false);
                spawnNote(4f, E3, false);
                break;
            case 2:
                spawnNote(1f, G4, false);
                break;
            case 3:
                spawnNote(1f, G4, false);
                break;
            case 4:
                spawnNote(1f, B4, false);
                break;
            case 5:
                spawnNote(1f, E5, false);
                spawnNote(1f, C3, false);
                break;
            case 6:
                spawnNote(1f, E5, false);
                break;
            case 7:
                spawnNote(1f, E5, false);
                break;
            case 8:
                spawnNote(1f, D5, false);
                break;
            default:
                print("End.");
                break;
        }

        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);
            spawnNote(1f, G2, false);
            // Code to execute after the delay
        }
    }
}
