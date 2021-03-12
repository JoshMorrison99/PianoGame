using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song2_See_you_Again : MonoBehaviour
{
    public PianoNoteSpawner spawner;

    /*  Note Durations Explained
     *  
     *  
     *  
     *  
     *
    */

    public int numNotes = 63;

    const int BPM = 88;
    const float SixteenthNote = 0.125f;
    const float EighthNote = 0.25f;
    const float QuarterNote = 0.5f;
    const float DottedQuartedNote = 0.75f;
    const float HalfNote = 1f;

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
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);  // Tie
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("QuarterNote", spawner.C5, false);  // Tie
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);  
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.A5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);

        // Bar 2
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("QuarterNote", spawner.C5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.A5, false);
        yield return new WaitForSeconds(QuarterNote);

        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.F5, false);
        yield return new WaitForSeconds(QuarterNote);
        spawner.spawnNote("QuarterNote", spawner.G5, false);
        yield return new WaitForSeconds(QuarterNote);

        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }


}


