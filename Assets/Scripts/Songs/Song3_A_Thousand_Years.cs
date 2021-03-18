using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song3_A_Thousand_Years : MonoBehaviour
{

    public PianoNoteSpawner spawner;

    /*  Note Durations Explained
     *  https://rechneronline.de/musik/note-length.php?
     *  
     *  Reference note = dotted quarter note
     *  Tempo = 50
     *
    */

 
    public int numNotes = 0;

    const int BPM = 50;
    const float SixteenthNote = 0.2f;
    const float EighthNote = 0.4f;
    const float QuarterNote = 0.8f;
    const float DottedQuartedNote = 1.2f;
    const float HalfNote = 1.6f;

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

        // Bar 1
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 2
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.C5, false);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 3
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 4
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.C5, false);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 5
        spawner.spawnNote("DottedQuartedNote", spawner.Ds5, true);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.Ds5, true);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 6
        spawner.spawnNote("DottedQuartedNote", spawner.Ds5, true);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.As4, true);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 7
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.D5, false);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 8
        spawner.spawnNote("DottedQuartedNote", spawner.C5, false);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("EighthNote", spawner.As4, true);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.A4, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F4, false);
        yield return new WaitForSeconds(EighthNote);

        //Bar 9
        spawner.spawnNote("QuarterNote", spawner.As4, true);
        yield return new WaitForSeconds(QuarterNote);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.As4, true);
        yield return new WaitForSeconds(QuarterNote);
        yield return new WaitForSeconds(EighthNote);

        //Bar 10
        spawner.spawnNote("QuarterNote", spawner.As4, true);
        yield return new WaitForSeconds(QuarterNote);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.D5, false);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("QuarterNote", spawner.As4, true);
        yield return new WaitForSeconds(QuarterNote);

        //Bar 11
        spawner.spawnNote("DottedQuartedNote", spawner.As4, true);
        yield return new WaitForSeconds(DottedQuartedNote);
        spawner.spawnNote("DottedQuartedNote", spawner.As4, true);
        yield return new WaitForSeconds(DottedQuartedNote);

        //Bar 12
        spawner.spawnNote("QuarterNote", spawner.As4, true);
        yield return new WaitForSeconds(QuarterNote);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.Ds5, true);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        yield return new WaitForSeconds(SixteenthNote);

        //Bar 13
        spawner.spawnNote("SixteenthNote", spawner.As4, true);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("QuarterNote", spawner.G4, false);
        yield return new WaitForSeconds(QuarterNote);
        yield return new WaitForSeconds(SixteenthNote);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("SixteenthNote", spawner.Ds5, true);
        yield return new WaitForSeconds(SixteenthNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        yield return new WaitForSeconds(SixteenthNote);

        //Bar 14
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("EighthNote", spawner.D5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("QuarterNote", spawner.A4, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("EighthNote", spawner.As4, true);
        yield return new WaitForSeconds(EighthNote);





        yield return new WaitForSeconds(5f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }


}


