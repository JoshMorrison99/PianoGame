using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{

    public int songNumber;
    public float numNotesTotal;
    public float numNotesHit;

    public GameObject piano;
    public Song song;



    float Song1_ScaleFactor_Piano = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        numNotesTotal = song.numNotes;
        numNotesHit = 0;

        // Setup song
        songNumber = PersistentData.data.selectedSong;
        ScaleScene(songNumber);

    }

    private void ScaleScene(int songNumber)
    {
        if (songNumber == 1)
        {
            // Scale Piano
            piano.transform.localScale = new Vector3(piano.transform.localScale.x * Song1_ScaleFactor_Piano, piano.transform.localScale.y * Song1_ScaleFactor_Piano, 1f);
            piano.transform.position = new Vector3(3.9f, 2.5f,0);
        }
        
    }
}
