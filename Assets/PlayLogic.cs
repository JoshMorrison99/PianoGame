using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{

    public PersistentData MyPersistentData;
    public int songNumber;
    public float numNotesTotal;
    public float numNotesHit;

    // Start is called before the first frame update
    void Start()
    {
        numNotesTotal = 0;
        numNotesHit = 0;

        MyPersistentData = GameObject.Find("GameLogic").GetComponent<PersistentData>();
        

        songNumber = MyPersistentData.selectedSong;

        if(songNumber == 1)
        {
            this.gameObject.AddComponent<Song1>();
            numNotesTotal = gameObject.GetComponent<Song1>().numNotes;
        }
    }
}
