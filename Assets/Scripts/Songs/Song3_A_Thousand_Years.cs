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
    const float SIXTEENTH = 0.2f;
    const float EIGHTH = 0.4f;
    const float QUARTER = 0.8f;
    const float DOTTED_QUARTER = 1.2f;
    const float HALF = 1.6f;

    const float SUB = 0.1f;                                                     // Makes it so the notes dont play directly after one another. This adds a small gap.


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
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.As3, true, DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER - SUB);               // Bass
        spawner.spawnNote(spawner.As2, true, DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER - SUB);               // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 2
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.C5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);
        spawner.spawnNote(spawner.A3, false, DOTTED_QUARTER - SUB);               // Bass
        spawner.spawnNote(spawner.A2, false, DOTTED_QUARTER - SUB);               // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 3
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.As3, true, DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER - SUB);               // Bass
        spawner.spawnNote(spawner.G2, false, DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER - SUB);               // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 4
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.C5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.F2, false, DOTTED_QUARTER - SUB);
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 5
        spawner.spawnNote(spawner.Ds5, true, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.G4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.Ds4, true, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.Ds2, true, DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER - SUB);               // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.Ds5, true, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.G4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.Ds4, true, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 6
        spawner.spawnNote(spawner.Ds5, true, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.G4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.Ds4, true, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.As4, true, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.Ds4, true, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 7
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        spawner.spawnNote(spawner.F2, false, DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER + DOTTED_QUARTER - SUB);               // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.D5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);

        // Bar 8
        spawner.spawnNote(spawner.C5, false, DOTTED_QUARTER - SUB);                                                 // Treble
        spawner.spawnNote(spawner.F4, false, DOTTED_QUARTER - SUB);                                                 // Bass
        yield return new WaitForSeconds(DOTTED_QUARTER);
        spawner.spawnNote(spawner.As4, true, EIGHTH - SUB);                                                 // Treble
        yield return new WaitForSeconds(EIGHTH);
        spawner.spawnNote(spawner.A4, false, EIGHTH - SUB);                                                 // Treble
        yield return new WaitForSeconds(EIGHTH);
        spawner.spawnNote(spawner.F4, false, EIGHTH - SUB);                                                 // Treble
        yield return new WaitForSeconds(EIGHTH);



        yield return new WaitForSeconds(10f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.UpdateFinishedSongText();
    }


}


