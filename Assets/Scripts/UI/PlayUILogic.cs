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

    public int songPercentage;

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
        PersistentData.SaveJsonData(PersistentData.data);
    }

    
}
