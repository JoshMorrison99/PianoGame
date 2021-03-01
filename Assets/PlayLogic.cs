using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{

    public SongInformation selectedSong;
    public int songNumber;

    // Start is called before the first frame update
    void Start()
    {
        selectedSong = GameObject.Find("GameLogic").GetComponent<SongInformation>();

        songNumber = selectedSong.selectedSong;

        if(songNumber == 1)
        {
            this.gameObject.AddComponent<Song1>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
