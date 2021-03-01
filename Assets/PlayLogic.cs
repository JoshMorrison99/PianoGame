using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{

    public SongInformation selectedSong;
    public int songNumber;
    public int numNotesTotal;
    public int numNotesHit;

    // Start is called before the first frame update
    void Start()
    {
        numNotesTotal = -1;
        numNotesHit = -1;

        selectedSong = GameObject.Find("GameLogic").GetComponent<SongInformation>();
        

        songNumber = selectedSong.selectedSong;

        if(songNumber == 1)
        {
            this.gameObject.AddComponent<Song1>();
            numNotesTotal = gameObject.GetComponent<Song1>().numNotes;
        }
    }
}
