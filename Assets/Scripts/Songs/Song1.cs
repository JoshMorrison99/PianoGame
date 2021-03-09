using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song1 : MonoBehaviour
{
    PianoNoteSpawner spawner;

    /*  Note Durations Explained
     *  BPM of Ode to Joy is 120 BPM
     *  2 Beats per second = 120 beats per minute (2 * 60 = 120)
     *  
     *  Half note               =  120 / BPM
        Quarter note            =   60 / BPM
        Eighth note             =   30 / BPM
        Sixteenth note          =   15 / BPM
        Dotted-quarter note     =   90 / BPM
        Dotted-eighth note      =   45 / BPM
        Dotted-sixteenth note   = 22.5 / BPM
        Triplet-quarter note    =   40 / BPM
        Triplet-eighth note     =   20 / BPM
        Triplet-sixteenth note  =   10 / BPM
     *  
     *
    */

    public int numNotes = 63;

    const int BPM = 120;
    const float SixteenthNote = 0.125f;
    const float EighthNote = 0.25f;
    const float QuarterNote = 0.5f;
    const float DottedQuartedNote = 0.75f;
    const float HalfNote = 1f;

    public PlayUILogic UILogic;

    private void Start()
    {
        
        numNotes = 63;

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();
        spawner.noteSpeed = 0.0065f;

        UILogic = GameObject.Find("Canvas").GetComponent<PlayUILogic>();

        StartCoroutine(BeginSong());
    }

    IEnumerator BeginSong()
    {
        // Bar 1
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 2
        spawner.spawnNote("QuarterNote", spawner.G3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 3
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 4
        spawner.spawnNote("DottedQuartedNote", spawner.E3, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.D3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.D3, false);
        yield return new WaitForSeconds(HalfNote);

        // Bar 5
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 6
        spawner.spawnNote("QuarterNote", spawner.G3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 7
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 8
        spawner.spawnNote("DottedQuartedNote", spawner.D3, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.C3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.C3, false);
        yield return new WaitForSeconds(HalfNote);

        // Bar 9
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 10
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("EighthNote", spawner.E3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 11
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("EighthNote", spawner.E3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 12
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("HalfNote", spawner.G2, false);
        yield return new WaitForSeconds(HalfNote);

        // Bar 13
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 14
        spawner.spawnNote("QuarterNote", spawner.G3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 15
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.D3, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.E3, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 16
        spawner.spawnNote("DottedQuartedNote", spawner.D3, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.C3, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.C3, false);
        yield return new WaitForSeconds(HalfNote);

        yield return new WaitForSeconds(5f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }
}
