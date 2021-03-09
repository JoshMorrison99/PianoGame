using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{

    public GameObject song;
    public float songSpeed = 0.004f;

    public GameObject piano;
    PlayUILogic UILogic;

    public GameObject EOS;

    public int numNotes = 63;

    // Start is called before the first frame update
    void Start()
    {
        piano.SetActive(true);
        UILogic = GameObject.Find("Canvas").GetComponent<PlayUILogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EOS.transform.position.y < 0)
        {
            EndOfSong();
        }
       song.transform.position = new Vector3(song.transform.position.x, song.transform.position.y - songSpeed, song.transform.position.z);
    }
    void EndOfSong()
    {
        piano.SetActive(false);
        UILogic.UpdateFinishedSongText();
    }

}
