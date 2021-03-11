using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUILogic : MonoBehaviour
{

    public PlayLogic playSongLogic;

    public GameObject songFinishedPanel;

    public TextMeshProUGUI progressSong;

    public GameObject healperLines;

    public GameObject pauseManuPanel;

    public GameObject piano;

    public GameObject pianoKeyLabels;

    public float songPercentage;

    // Start is called before the first frame update
    void Start()
    {
        pianoKeyLabels.SetActive(true);
        healperLines.SetActive(true);
        songFinishedPanel.SetActive(false);
        pauseManuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        songPercentage = playSongLogic.numNotesHit / playSongLogic.numNotesTotal;
        progressSong.text = playSongLogic.numNotesHit + "/" + playSongLogic.numNotesTotal;
    }

    public void UpdateFinishedSongText()
    {
        // set the song finished panel to active
        songFinishedPanel.SetActive(true);

        piano.SetActive(false);
        pianoKeyLabels.SetActive(false);

        songFinishedPanel.GetComponent<SongFinished>().UpdateText();

        // remove the helper lines from the UI
        healperLines.SetActive(false);

        // Save data
        updateUserScore();
        PersistentData.SaveJsonData(PersistentData.data);
    }

    void updateUserScore()
    {
        if (songPercentage > PersistentData.data.song_Ode_To_Joy_Completion)
        {
            PersistentData.data.song_Ode_To_Joy_Completion = songPercentage;
        }
    }
}
