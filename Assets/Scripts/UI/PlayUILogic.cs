using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayUILogic : MonoBehaviour
{

    public PlayLogic Logic;

    public MidiMagic midi;

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

    public TextMeshProUGUI scoreText;

    public Toggle pianoLabelToggle;
    public Toggle noteLabelToggle;

    public Slider SongSpeedSlider;
    public Slider SongVolumeSlider;


    public int songPercentage;

    // Start is called before the first frame update
    void Start()
    {

        

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();

        isPaused = false;
        ActivateGame();


        pauseBtn.onClick.AddListener(PauseMenuPressed);
        pauseMainMenuButton.onClick.AddListener(PauseMainMenuClicked);
        pauseReplayButton.onClick.AddListener(PauseReplayClicked);
        pauseSettingsButton.onClick.AddListener(PauseSettingsClicked);
        pauseResumeButton.onClick.AddListener(PauseMenuPressed);

        InitSettings();

        pianoBackground.SetActive(true);
        healperLines.SetActive(true);
        songFinishedPanel.SetActive(false);
        pauseManuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pauseBtn.gameObject.SetActive(true);


        //PauseMenuPressed();
    }

    // Update is called once per frame
    void Update()
    {
        progressSong.text = Logic.numNotesHit + "/" + Logic.numNotesTotal;

        scoreText.text = Logic.currentScore.ToString();
    }

    public void InitSettings()
    {
        if (PlayerPrefs.GetInt("isPianoLabelled") == 1)
        {
            pianoLabelToggle.isOn = true;
            
        }
        else
        {
            pianoLabelToggle.isOn = false;
            
        }

        if (PlayerPrefs.GetInt("isNoteLabelled") == 1)
        {
            noteLabelToggle.isOn = true;
            spawner.isNoteLabelled = true;
        }
        else
        {
            noteLabelToggle.isOn = false;
            spawner.isNoteLabelled = false;
        }
    }

    public void UpdateFinishedSongText()
    {
        pauseBtn.gameObject.SetActive(false);
        pianoBackground.SetActive(false);

        // set the song finished panel to active
        songFinishedPanel.SetActive(true);

        piano.SetActive(false);
        pianoKeyLabels.SetActive(false);

        // remove the helper lines from the UI
        healperLines.SetActive(false);

        // Remove toggles
        pianoLabelToggle.gameObject.SetActive(false);
        noteLabelToggle.gameObject.SetActive(false);

        songFinishedPanel.GetComponent<SongFinished>().UpdateText();

        
    }

    public void SongSpeedSliderChangedValue()
    {
        float newSongSpeed = SongSpeedSlider.value;
        //Debug.Log(newSongSpeed);
        midi.ChangeMidiPlaybackSpeed(newSongSpeed);
    }

    public void SongVolumeSliderChangedValue()
    {
        float newSongVolume = SongVolumeSlider.value;
        const int volumeUIntMutiplier = 65535;
        midi.ChangedMidiPlaybackVolume(newSongVolume * volumeUIntMutiplier);
    }

    public void PauseMenuPressed()
    {
        if (isPaused)
        {
            spawner.noteSpeed = PersistentData.data.songSpeed;
            pauseManuPanel.SetActive(false);
            isPaused = false;
            midi.ResumePlayback();
            PersistentData.data.isPaused = false;
            Time.timeScale = 1;
            Debug.Log("Button Setting to False");
        }
        else
        {
            spawner.noteSpeed = 0;
            pauseManuPanel.SetActive(true);
            isPaused = true;
            midi._playback.Stop();
            PersistentData.data.isPaused = true;
            Time.timeScale = 0.00001f;
            Debug.Log("Button Setting to True");
        }
        
       
    }

    void ActivateGame()
    {
        spawner.noteSpeed = PersistentData.data.songSpeed;
        pauseManuPanel.SetActive(false);
        isPaused = false;
        //midi.ResumePlayback();
        PersistentData.data.isPaused = false;
        Time.timeScale = 1;
        Debug.Log("Button Setting to False");
    }

    public void PauseMainMenuClicked()
    {
        midi.ReplaySong();
        SceneManager.LoadScene("MainMenu");
        Debug.Log("REPLAY");
    }

    public void PauseReplayClicked()
    {
        midi.ReplaySong();
        SceneManager.LoadScene("Play");
        
    }

    public void PauseSettingsClicked()
    {
        piano.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void TogglePianoLabels()
    {
        if (pianoLabelToggle.isOn)
        {
            pianoKeyLabels.SetActive(true);
            PlayerPrefs.SetInt("isPianoLabelled", 1);
        }
        else
        {
            pianoKeyLabels.SetActive(false);
            PlayerPrefs.SetInt("isPianoLabelled", 0);
        }
    }

    public void ToggleNoteLabels()
    {
        if (noteLabelToggle.isOn)
        {
            spawner.isNoteLabelled = true;
            PlayerPrefs.SetInt("isNoteLabelled", 1);
        }
        else
        {
            spawner.isNoteLabelled = false;
            PlayerPrefs.SetInt("isNoteLabelled", 0);
        }
    }


}
