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
        spawner.spawnNote(spawner.D5, false, HalfNote);


        yield return new WaitForSeconds(5f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }


}


