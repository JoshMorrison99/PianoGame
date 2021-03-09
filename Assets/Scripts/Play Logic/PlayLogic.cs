using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLogic : MonoBehaviour
{

    public int songNumber;
    public float numNotesTotal;
    public float numNotesHit;

    public GameObject piano;
    public GameObject pianoLine;

    public GameObject HelperLine1;
    public GameObject HelperLine2;
    public GameObject HelperLine3;
    public GameObject HelperLine4;
    public GameObject HelperLine5;
    public GameObject HelperLine6;

    public GameObject C2_Label;
    public GameObject C3_Label;
    public GameObject C4_Label;
    public GameObject C5_Label;
    public GameObject C6_Label;

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

            // Sacel top bar
            pianoLine.transform.position = new Vector3(0, 405,0);

            // scale healper lines
            HelperLine1.transform.localPosition = new Vector3(-709f, 271f,0);
            HelperLine2.transform.localPosition = new Vector3(-381f, 271f,0);
            HelperLine3.transform.localPosition = new Vector3(-134f, 271f,0);
            HelperLine4.transform.localPosition = new Vector3(194f, 271f, 0);
            HelperLine5.transform.localPosition = new Vector3(440f, 271f,0);
            HelperLine6.transform.localPosition = new Vector3(768f, 271f,0);

            // Scale helper keys
            C2_Label.transform.localPosition = new Vector3(-843f, -520f, 0);
            C3_Label.transform.localPosition = new Vector3(-268f, -520f, 0);
            C4_Label.transform.localPosition = new Vector3(305f, -520f, 0);
            C5_Label.transform.localPosition = new Vector3(881f, -520f, 0);
            C6_Label.transform.localPosition = new Vector3(1741f, -520f, 0);
        }
        
    }
}
