using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayUILogic : MonoBehaviour
{

    public PlayLogic playSongLogic;

    public GameObject songFinishedPanel;

    public TextMeshProUGUI progressSong;

    public GameObject healperLines;

    public GameObject pauseManuPanel;
    public Button pauseMainMenuButton;
    public Button pauseReplayButton;
    public Button pauseSettingsButton;
    public Button pauseResumeButton;

    public GameObject piano;

    public GameObject pianoKeyLabels;

    public PianoNoteSpawner spawner;

    public Button pauseBtn;

    public GameObject settingsPanel;

    public bool isPaused;

    public GameObject pianoBackground;


    public int songPercentage;

    // Start is called before the first frame update
    void Start()
    {
        
        isPaused = true;

        
        pauseBtn.onClick.AddListener(PauseMenuPressed);
        pauseMainMenuButton.onClick.AddListener(PauseMainMenuClicked);
        pauseReplayButton.onClick.AddListener(PauseReplayClicked);
        pauseSettingsButton.onClick.AddListener(PauseSettingsClicked);
        pauseResumeButton.onClick.AddListener(PauseMenuPressed);

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();

        pianoBackground.SetActive(true);
        pianoKeyLabels.SetActive(true);
        healperLines.SetActive(true);
        songFinishedPanel.SetActive(false);
        pauseManuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pauseBtn.gameObject.SetActive(true);

        PauseMenuPressed();
    }

    // Update is called once per frame
    void Update()
    {
        progressSong.text = playSongLogic.numNotesHit + "/" + playSongLogic.numNotesTotal;
    }

    public void UpdateFinishedSongText()
    {
        pauseBtn.gameObject.SetActive(false);
        pianoBackground.SetActive(false);

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
        if (isPaused)
        {
            spawner.noteSpeed = PersistentData.data.songSpeed;
            pauseManuPanel.SetActive(false);
            isPaused = false;
            PersistentData.data.isPaused = false;
            Time.timeScale = 1;
            Debug.Log("Button Setting to False");
        }
        else
        {
            spawner.noteSpeed = 0;
            pauseManuPanel.SetActive(true);
            isPaused = true;
            PersistentData.data.isPaused = true;
            Time.timeScale = 0.00001f;
            Debug.Log("Button Setting to True");
        }
        
       
    }

    public void PauseMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseReplayClicked()
    {
        SceneManager.LoadScene("Play");
    }

    public void PauseSettingsClicked()
    {
        piano.SetActive(false);
        settingsPanel.SetActive(true);
    }


}
