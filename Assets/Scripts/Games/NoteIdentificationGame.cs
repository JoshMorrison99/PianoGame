using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Devices;
using UnityEngine.InputSystem;

public class NoteIdentificationGame : MonoBehaviour
{
    // Game Logic
    public bool isBass;
    string[] noteRange = {"C0","D0","E0","F0","G0","A0","B0",
                        "C1","D1","E1","F1","G1","A1","B1",
                        "C2","D2","E2","F2","G2","A2","B2",
                        "C3","D3","E3","F3","G3","A3","B3",
                        "C4","D4","E4","F4","G4","A4","B4",
                        "C5","D5","E5","F5","G5","A5","B5",
                        "C6","D6","E6","F6","G6","A6","B6",
                        "C7","D7","E7","F7","G7","A7","B7",
                        "C8","D8","E8","F8","G8","A8","B8",
                        "C9","D9","E9","F9","G9","A9","B9" };
    public string topNote;
    public int topNoteIndex;
    public string bottomNote;
    public int bottomNoteIndex;
    public int bassLineTrebleIndex;
    public int bassLineBassIndex;
    public bool isSharp;
    public int CorrectlyHitNotes;



    public PianoKeyPresses pianoListRef;

    public bool isNoteLabelled = true;


    // Piano Notes
    public GameObject C0;
    public GameObject D0;
    public GameObject E0;
    public GameObject F0;
    public GameObject G0;
    public GameObject A0;
    public GameObject B0;
    public GameObject Cs0;
    public GameObject Ds0;
    public GameObject Fs0;
    public GameObject Gs0;
    public GameObject As0;

    public GameObject C1;
    public GameObject D1;
    public GameObject E1;
    public GameObject F1;
    public GameObject G1;
    public GameObject A1;
    public GameObject B1;
    public GameObject Cs1;
    public GameObject Ds1;
    public GameObject Fs1;
    public GameObject Gs1;
    public GameObject As1;

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

    public GameObject C7;
    public GameObject D7;
    public GameObject E7;
    public GameObject F7;
    public GameObject G7;
    public GameObject A7;
    public GameObject B7;
    public GameObject Cs7;
    public GameObject Ds7;
    public GameObject Fs7;
    public GameObject Gs7;
    public GameObject As7;

    public GameObject C8;
    public GameObject D8;
    public GameObject E8;
    public GameObject F8;
    public GameObject G8;
    public GameObject A8;
    public GameObject B8;
    public GameObject Cs8;
    public GameObject Ds8;
    public GameObject Fs8;
    public GameObject Gs8;
    public GameObject As8;

    PianoKeyPresses PianoKeysObject;
    int index;
    public bool isPlaying;
    public TextMeshProUGUI correctlyHitNoteText;


    private void Start()
    {
        //setupUI();
        PianoKeysObject = GameObject.Find("PianoKeyboardUI").GetComponent<PianoKeyPresses>();
        DeviceFinder.device.GetPianoDeviceErrorText();
        setupUI();
        bassLineTrebleIndex = 34;
        bassLineBassIndex = 22;

        CorrectlyHitNotes = 0;
        correctlyHitNoteText.text = CorrectlyHitNotes.ToString();
}

    

    public float CreateRandomPosition(float wholeNoteImage)
    {
        index = Random.Range(bottomNoteIndex, topNoteIndex);
        Debug.Log("RANDOM INDEX " + index);
        Debug.Log("TOP INDEX " + topNoteIndex);
        Debug.Log("Bottom INDEX " + bottomNoteIndex);
        int indicesToMove = 0;
        float randomPos = wholeNoteImage;
        if (isBass)
        {
            indicesToMove = index - bassLineBassIndex;
            Debug.Log("indicesToMove " + indicesToMove);
        }
        else
        {
            indicesToMove = index - bassLineTrebleIndex;
            Debug.Log("indicesToMove " + indicesToMove);
        }

        if (indicesToMove > 0)
        {
            for (int i = 0; i < indicesToMove; i++)
            {
                randomPos += 22.5f;
            }
        }else if (indicesToMove < 0)
        {
            for (int i = 0; i > indicesToMove; i--)
            {
                randomPos -= 22.5f;
            }
        }

        Debug.Log("RANDOM POSITION " + randomPos);
        return randomPos;
    }

    public void StartGame(GameObject wholeNoteImage)
    {
        wholeNoteImage.transform.localPosition = new Vector3(wholeNoteImage.transform.localPosition.x, 0, 0);
        float randomPos = CreateRandomPosition(wholeNoteImage.transform.localPosition.y);
        wholeNoteImage.transform.localPosition = new Vector3(wholeNoteImage.transform.localPosition.x, wholeNoteImage.transform.localPosition.y + randomPos, 0);

        isPlaying = true;
        StartCoroutine(Looper(wholeNoteImage));
        

    }

    public IEnumerator Looper(GameObject wholeNoteImage)
    {
        while (isPlaying)
        {
            foreach (GameObject note in pianoListRef.currentPressedNotes)
            {
                Debug.Log(note.GetComponent<Note_Mine>().noteName);
                if(note.GetComponent<Note_Mine>().noteName == noteRange[index])
                {
                    isPlaying = false;
                    CorrectlyHitNotes += 1;
                    correctlyHitNoteText.text = CorrectlyHitNotes.ToString();
                    break;
                }
            }
            yield return null;

        }

        StartGame(wholeNoteImage);

    }

    public void setupUI()
    {
        // Octave 0
        C0 = pianoListRef.PianoKeys[0];
        C0.GetComponent<Note_Mine>().noteName = "C0";
        D0 = pianoListRef.PianoKeys[1];
        D0.GetComponent<Note_Mine>().noteName = "D0";
        E0 = pianoListRef.PianoKeys[2];
        E0.GetComponent<Note_Mine>().noteName = "E0";
        F0 = pianoListRef.PianoKeys[3];
        F0.GetComponent<Note_Mine>().noteName = "F0";
        G0 = pianoListRef.PianoKeys[4];
        G0.GetComponent<Note_Mine>().noteName = "G0";
        A0 = pianoListRef.PianoKeys[5];
        A0.GetComponent<Note_Mine>().noteName = "A0";
        B0 = pianoListRef.PianoKeys[6];
        B0.GetComponent<Note_Mine>().noteName = "B0";
        Cs0 = pianoListRef.PianoKeys[7];
        Cs0.GetComponent<Note_Mine>().noteName = "C#0";
        Ds0 = pianoListRef.PianoKeys[8];
        Ds0.GetComponent<Note_Mine>().noteName = "D#0";
        Fs0 = pianoListRef.PianoKeys[9];
        Fs0.GetComponent<Note_Mine>().noteName = "F#0";
        Gs0 = pianoListRef.PianoKeys[10];
        Gs0.GetComponent<Note_Mine>().noteName = "G#0";
        As0 = pianoListRef.PianoKeys[11];
        As0.GetComponent<Note_Mine>().noteName = "A#0";

        // Octave 1
        C1 = pianoListRef.PianoKeys[12];
        C1.GetComponent<Note_Mine>().noteName = "C1";
        D1 = pianoListRef.PianoKeys[13];
        D1.GetComponent<Note_Mine>().noteName = "D1";
        E1 = pianoListRef.PianoKeys[14];
        E1.GetComponent<Note_Mine>().noteName = "E1";
        F1 = pianoListRef.PianoKeys[15];
        F1.GetComponent<Note_Mine>().noteName = "F1";
        G1 = pianoListRef.PianoKeys[16];
        G1.GetComponent<Note_Mine>().noteName = "G1";
        A1 = pianoListRef.PianoKeys[17];
        A1.GetComponent<Note_Mine>().noteName = "A1";
        B1 = pianoListRef.PianoKeys[18];
        B1.GetComponent<Note_Mine>().noteName = "B1";
        Cs1 = pianoListRef.PianoKeys[19];
        Cs1.GetComponent<Note_Mine>().noteName = "C#1";
        Ds1 = pianoListRef.PianoKeys[20];
        Ds1.GetComponent<Note_Mine>().noteName = "D#1";
        Fs1 = pianoListRef.PianoKeys[21];
        Fs1.GetComponent<Note_Mine>().noteName = "F#1";
        Gs1 = pianoListRef.PianoKeys[22];
        Gs1.GetComponent<Note_Mine>().noteName = "G#1";
        As1 = pianoListRef.PianoKeys[23];
        As1.GetComponent<Note_Mine>().noteName = "A#1";

        // Octave 2
        C2 = pianoListRef.PianoKeys[24];
        C2.GetComponent<Note_Mine>().noteName = "C2";
        D2 = pianoListRef.PianoKeys[25];
        D2.GetComponent<Note_Mine>().noteName = "D2";
        E2 = pianoListRef.PianoKeys[26];
        E2.GetComponent<Note_Mine>().noteName = "E2";
        F2 = pianoListRef.PianoKeys[27];
        F2.GetComponent<Note_Mine>().noteName = "F2";
        G2 = pianoListRef.PianoKeys[28];
        G2.GetComponent<Note_Mine>().noteName = "G2";
        A2 = pianoListRef.PianoKeys[29];
        A2.GetComponent<Note_Mine>().noteName = "A2";
        B2 = pianoListRef.PianoKeys[30];
        B2.GetComponent<Note_Mine>().noteName = "B2";
        Cs2 = pianoListRef.PianoKeys[31];
        Cs2.GetComponent<Note_Mine>().noteName = "C#2";
        Ds2 = pianoListRef.PianoKeys[32];
        Ds2.GetComponent<Note_Mine>().noteName = "D#2";
        Fs2 = pianoListRef.PianoKeys[33];
        Fs2.GetComponent<Note_Mine>().noteName = "F#2";
        Gs2 = pianoListRef.PianoKeys[34];
        Gs2.GetComponent<Note_Mine>().noteName = "G#2";
        As2 = pianoListRef.PianoKeys[35];
        As2.GetComponent<Note_Mine>().noteName = "A#2";

        // Octave 3
        C3 = pianoListRef.PianoKeys[36];
        C3.GetComponent<Note_Mine>().noteName = "C3";
        D3 = pianoListRef.PianoKeys[37];
        D3.GetComponent<Note_Mine>().noteName = "D3";
        E3 = pianoListRef.PianoKeys[38];
        E3.GetComponent<Note_Mine>().noteName = "E3";
        F3 = pianoListRef.PianoKeys[39];
        F3.GetComponent<Note_Mine>().noteName = "F3";
        G3 = pianoListRef.PianoKeys[40];
        G3.GetComponent<Note_Mine>().noteName = "G3";
        A3 = pianoListRef.PianoKeys[41];
        A3.GetComponent<Note_Mine>().noteName = "A3";
        B3 = pianoListRef.PianoKeys[42];
        B3.GetComponent<Note_Mine>().noteName = "B3";
        Cs3 = pianoListRef.PianoKeys[43];
        Cs3.GetComponent<Note_Mine>().noteName = "C#3";
        Ds3 = pianoListRef.PianoKeys[44];
        Ds3.GetComponent<Note_Mine>().noteName = "D#3";
        Fs3 = pianoListRef.PianoKeys[45];
        Fs3.GetComponent<Note_Mine>().noteName = "F#3";
        Gs3 = pianoListRef.PianoKeys[46];
        Gs3.GetComponent<Note_Mine>().noteName = "G#3";
        As3 = pianoListRef.PianoKeys[47];
        As3.GetComponent<Note_Mine>().noteName = "A#3";

        // Octave 4
        C4 = pianoListRef.PianoKeys[48];
        C4.GetComponent<Note_Mine>().noteName = "C4";
        D4 = pianoListRef.PianoKeys[49];
        D4.GetComponent<Note_Mine>().noteName = "D4";
        E4 = pianoListRef.PianoKeys[50];
        E4.GetComponent<Note_Mine>().noteName = "E4";
        F4 = pianoListRef.PianoKeys[51];
        F4.GetComponent<Note_Mine>().noteName = "F4";
        G4 = pianoListRef.PianoKeys[52];
        G4.GetComponent<Note_Mine>().noteName = "G4";
        A4 = pianoListRef.PianoKeys[53];
        A4.GetComponent<Note_Mine>().noteName = "A4";
        B4 = pianoListRef.PianoKeys[54];
        B4.GetComponent<Note_Mine>().noteName = "B4";
        Cs4 = pianoListRef.PianoKeys[55];
        Cs4.GetComponent<Note_Mine>().noteName = "C#4";
        Ds4 = pianoListRef.PianoKeys[56];
        Ds4.GetComponent<Note_Mine>().noteName = "D#4";
        Fs4 = pianoListRef.PianoKeys[57];
        Fs4.GetComponent<Note_Mine>().noteName = "F#4";
        Gs4 = pianoListRef.PianoKeys[58];
        Gs4.GetComponent<Note_Mine>().noteName = "G#4";
        As4 = pianoListRef.PianoKeys[59];
        As4.GetComponent<Note_Mine>().noteName = "A#4";

        // Octave 5
        C5 = pianoListRef.PianoKeys[60];
        C5.GetComponent<Note_Mine>().noteName = "C5";
        D5 = pianoListRef.PianoKeys[61];
        D5.GetComponent<Note_Mine>().noteName = "D5";
        E5 = pianoListRef.PianoKeys[62];
        E5.GetComponent<Note_Mine>().noteName = "E5";
        F5 = pianoListRef.PianoKeys[63];
        F5.GetComponent<Note_Mine>().noteName = "F5";
        G5 = pianoListRef.PianoKeys[64];
        G5.GetComponent<Note_Mine>().noteName = "G5";
        A5 = pianoListRef.PianoKeys[65];
        A5.GetComponent<Note_Mine>().noteName = "A5";
        B5 = pianoListRef.PianoKeys[66];
        B5.GetComponent<Note_Mine>().noteName = "B5";
        Cs5 = pianoListRef.PianoKeys[67];
        Cs5.GetComponent<Note_Mine>().noteName = "C#5";
        Ds5 = pianoListRef.PianoKeys[68];
        Ds5.GetComponent<Note_Mine>().noteName = "D#5";
        Fs5 = pianoListRef.PianoKeys[69];
        Fs5.GetComponent<Note_Mine>().noteName = "F#5";
        Gs5 = pianoListRef.PianoKeys[70];
        Gs5.GetComponent<Note_Mine>().noteName = "G#5";
        As5 = pianoListRef.PianoKeys[71];
        As5.GetComponent<Note_Mine>().noteName = "A#5";

        // Octave 6
        C6 = pianoListRef.PianoKeys[72];
        C6.GetComponent<Note_Mine>().noteName = "C6";
        D6 = pianoListRef.PianoKeys[73];
        D6.GetComponent<Note_Mine>().noteName = "D6";
        E6 = pianoListRef.PianoKeys[74];
        E6.GetComponent<Note_Mine>().noteName = "E6";
        F6 = pianoListRef.PianoKeys[75];
        F6.GetComponent<Note_Mine>().noteName = "F6";
        G6 = pianoListRef.PianoKeys[76];
        G6.GetComponent<Note_Mine>().noteName = "G6";
        A6 = pianoListRef.PianoKeys[77];
        A6.GetComponent<Note_Mine>().noteName = "A6";
        B6 = pianoListRef.PianoKeys[78];
        B6.GetComponent<Note_Mine>().noteName = "B6";
        Cs6 = pianoListRef.PianoKeys[79];
        Cs6.GetComponent<Note_Mine>().noteName = "C#6";
        Ds6 = pianoListRef.PianoKeys[80];
        Ds6.GetComponent<Note_Mine>().noteName = "D#6";
        Fs6 = pianoListRef.PianoKeys[81];
        Fs6.GetComponent<Note_Mine>().noteName = "F#6";
        Gs6 = pianoListRef.PianoKeys[82];
        Gs6.GetComponent<Note_Mine>().noteName = "G#6";
        As6 = pianoListRef.PianoKeys[83];
        As6.GetComponent<Note_Mine>().noteName = "A#6";

        // Octave 7
        C7 = pianoListRef.PianoKeys[84];
        C7.GetComponent<Note_Mine>().noteName = "C7";
        D7 = pianoListRef.PianoKeys[85];
        D7.GetComponent<Note_Mine>().noteName = "D7";
        E7 = pianoListRef.PianoKeys[86];
        E7.GetComponent<Note_Mine>().noteName = "E7";
        F7 = pianoListRef.PianoKeys[87];
        F7.GetComponent<Note_Mine>().noteName = "F7";
        G7 = pianoListRef.PianoKeys[88];
        G7.GetComponent<Note_Mine>().noteName = "G7";
        A7 = pianoListRef.PianoKeys[89];
        A7.GetComponent<Note_Mine>().noteName = "A7";
        B7 = pianoListRef.PianoKeys[90];
        B7.GetComponent<Note_Mine>().noteName = "B7";
        Cs7 = pianoListRef.PianoKeys[91];
        Cs7.GetComponent<Note_Mine>().noteName = "C#7";
        Ds7 = pianoListRef.PianoKeys[92];
        Ds7.GetComponent<Note_Mine>().noteName = "D#7";
        Fs7 = pianoListRef.PianoKeys[93];
        Fs7.GetComponent<Note_Mine>().noteName = "F#7";
        Gs7 = pianoListRef.PianoKeys[94];
        Gs7.GetComponent<Note_Mine>().noteName = "G#7";
        As7 = pianoListRef.PianoKeys[95];
        As7.GetComponent<Note_Mine>().noteName = "A#7";

        // Octave 8
        C8 = pianoListRef.PianoKeys[96];
        C8.GetComponent<Note_Mine>().noteName = "C8";
        D8 = pianoListRef.PianoKeys[97];
        D8.GetComponent<Note_Mine>().noteName = "D8";
        E8 = pianoListRef.PianoKeys[98];
        E8.GetComponent<Note_Mine>().noteName = "E8";
        F8 = pianoListRef.PianoKeys[99];
        F8.GetComponent<Note_Mine>().noteName = "F8";
        G8 = pianoListRef.PianoKeys[100];
        G8.GetComponent<Note_Mine>().noteName = "G8";
        A8 = pianoListRef.PianoKeys[101];
        A8.GetComponent<Note_Mine>().noteName = "A8";
        B8 = pianoListRef.PianoKeys[102];
        B8.GetComponent<Note_Mine>().noteName = "B8";
        Cs8 = pianoListRef.PianoKeys[103];
        Cs8.GetComponent<Note_Mine>().noteName = "C#8";
        Ds8 = pianoListRef.PianoKeys[104];
        Ds8.GetComponent<Note_Mine>().noteName = "D#8";
        Fs8 = pianoListRef.PianoKeys[105];
        Fs8.GetComponent<Note_Mine>().noteName = "F#8";
        Gs8 = pianoListRef.PianoKeys[106];
        Gs8.GetComponent<Note_Mine>().noteName = "G#8";
        As8 = pianoListRef.PianoKeys[107];
        As8.GetComponent<Note_Mine>().noteName = "A#8";
    }
}
