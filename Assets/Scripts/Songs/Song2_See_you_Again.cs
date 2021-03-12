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

    public int numNotes = 63;

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

        numNotes = 63;

        UILogic = GameObject.Find("Canvas").GetComponent<PlayUILogic>();

        StartCoroutine(BeginSong());
    }

    IEnumerator BeginSong()
    {
        // Bar 1
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.C5, false); 
        yield return new WaitForSeconds(HalfNote);

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

        // Bar 2
        spawner.spawnNote("EighthNote", spawner.C5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.G5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("EighthNote", spawner.F5, false);
        yield return new WaitForSeconds(EighthNote);
        spawner.spawnNote("HalfNote", spawner.C5, false);
        yield return new WaitForSeconds(HalfNote);

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

        yield return new WaitForSeconds(5f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }


}


