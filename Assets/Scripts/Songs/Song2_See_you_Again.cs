using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song2_See_you_Again : MonoBehaviour
{
    public PianoNoteSpawner spawner;

    /*  Note Durations Explained
     *  https://rechneronline.de/musik/note-length.php?
     *  
     *  
     *  
     *
    */

    public int numNotes = 296;

    const int BPM = 88;
    const float SixteenthNote = 0.170f;
    const float EighthNote = 0.341f;
    const float QuarterNote = 0.682f;
    const float DottedQuartedNote = 1.023f;
    const float HalfNote = 1.364f;

    public PlayUILogic UILogic;

    private void Start()
    {
        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();
        spawner.noteSpeed = 0.05f;
        PersistentData.data.songSpeed = 0.05f;

        numNotes = 296;

        UILogic = GameObject.Find("Canvas").GetComponent<PlayUILogic>();

        StartCoroutine(BeginSong());
    }

    IEnumerator BeginSong()
    {
       /* // Bar 1
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false); 
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("SixteenthNote", spawner.F5, false);  
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.A5, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        //10
        // Bar 2
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.A5, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        //20
        // Bar 3
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.A5, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        //30
        // Bar 4
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //37
        // Bar 5
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("HalfNote", spawner.C5, false);
        yield return new WaitForSeconds(HalfNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        //40
        // Bar 6
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //46
        // Bar 7
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        //54
        // Bar 8
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.E4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.E4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //61
        // Bar 9
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("HalfNote", spawner.C5, false);
        yield return new WaitForSeconds(HalfNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        //64
        // Bar 10
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //70
        // Bar 11
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        //78
        // Bar 12
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        //84
        // Bar 13
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.F5, false);
        yield return new WaitForSeconds(HalfNote);
        //88
        // Bar 14
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.C5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);
        //101
        // Bar 15
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        //108
        // Bar 16
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("QuarterNote", spawner.G4, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 17
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.F4, false);
        yield return new WaitForSeconds(HalfNote);       // This is supposed to be a quarter note + a half note
        //119
        // Bar 18
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //127
        // Bar 19
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        //133
        // Bar 20
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.C5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        //137
        // Bar 21
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("SixteenthNote", spawner.C5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        //146
        // Bar 22
        spawner.spawnNote("EighthNote", spawner.A5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.A5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        //154
        // Bar 23
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.F5, false);
        yield return new WaitForSeconds(HalfNote);
        //158
        // Bar 24
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.C5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.A4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G4, false);
        yield return new WaitForSeconds(SixteenthNote);
        //171
        // Bar 25
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        //178
        // Bar 26
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        //184
        // Bar 27
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.F4, false);
        yield return new WaitForSeconds(HalfNote);
        //189
        // Bar 28
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.F4, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D4, false);
        yield return new WaitForSeconds(SixteenthNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //197
        // Bar 29
        spawner.spawnNote("HalfNote", spawner.D4, false);
        yield return new WaitForSeconds(HalfNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("HalfNote", spawner.G4, false);
        spawner.spawnNote("HalfNote", spawner.F4, false);
        yield return new WaitForSeconds(HalfNote);

        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        //203
        // Bar 30
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("HalfNote", spawner.C5, false);
        yield return new WaitForSeconds(HalfNote);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        //213
        // Bar 31
        spawner.spawnNote("EighthNote", spawner.As4, true);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //218
        // Bar 32
        spawner.spawnNote("QuarterNote", spawner.A5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("HalfNote", spawner.D5, false);
        yield return new WaitForSeconds(HalfNote);
        spawner.spawnNote("DottedQuartedNote", spawner.E5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        //225
        // Bar 33
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("DottedQuartedNote", spawner.F5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //230
        // Bar 34
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("HalfNote", spawner.C5, false);
        yield return new WaitForSeconds(HalfNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //239
        // Bar 35
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        //247
        // Bar 36
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //254
        // Bar 37
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("HalfNote", spawner.C5, false);
        yield return new WaitForSeconds(HalfNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        //257
        // Bar 38
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        //263
        // Bar 39
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        //271
        // Bar 40
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        //277
        // Bar 41
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        //283
        // Bar 42
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.C5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        //287
        // Bar 43
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.E5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);

        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("SixteenthNote", spawner.C5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.D5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.F5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("SixteenthNote", spawner.G5, false);
        yield return new WaitForSeconds(SixteenthNote);
        //296*/




        yield return new WaitForSeconds(5f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }


}


