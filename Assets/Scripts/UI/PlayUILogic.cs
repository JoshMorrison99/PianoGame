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

    public PianoNoteSpawner spawner;

    public Button pauseBtn;

    public bool isPaused;


    public int songPercentage;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;

        pauseBtn.onClick.AddListener(PauseMenuPressed);

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();

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

    public void PauseMenuPressed()
    {
        Debug.Log("Button" + isPaused);
        if (isPaused)
        {
            spawner.noteSpeed = PersistentData.data.songSpeed;
            pauseManuPanel.SetActive(false);
            isPaused = false;
            PersistentData.data.isPaused = false;
            Time.timeScale = 1;
        }
        else
        {
            spawner.noteSpeed = 0;
            pauseManuPanel.SetActive(true);
            isPaused = true;
            PersistentData.data.isPaused = true;
            Time.timeScale = 0.00001f;
        }
        
       
    }

    
}
