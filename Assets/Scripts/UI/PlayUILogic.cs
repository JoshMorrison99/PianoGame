using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayUILogic : MonoBehaviour
{

    public delegate void ButtonClickedAction();
    public static event ButtonClickedAction buttonClickedEvent;

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

    public Slider speedSlider;


    public int songPercentage;

    // Start is called before the first frame update
    void Start()
    {

        DeviceFinder deviceFinder = GameObject.Find("DeviceFinder").GetComponent<DeviceFinder>();
        deviceFinder.GetPianoDeviceErrorText();

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

        // Disable the slider for playback speed so the user cannot change the speed while playing
        speedSlider.enabled = false;
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
            pianoKeyLabels.SetActive(true);

        }
        else
        {
            pianoKeyLabels.SetActive(false);

        }

        if (PlayerPrefs.GetInt("isNoteLabelled") == 1)
        {
            spawner.isNoteLabelled = true;
        }
        else
        {
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
        scoreText.gameObject.SetActive(false);
        progressSong.gameObject.SetActive(false);

        // remove the helper lines from the UI
        healperLines.SetActive(false);

        songFinishedPanel.GetComponent<SongFinished>().UpdateText();

        
    }

    public void GetAndSetSongVolume()
    {
        float newSongVolume = PlayerPrefs.GetFloat("Volume");
        Debug.Log("Volume " + newSongVolume);
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
            midi._playback_audio.Stop();
            PersistentData.data.isPaused = true;
            Time.timeScale = 0.00001f;
            Debug.Log("Button Setting to True");
        }

        // play button clicked sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
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
        // play button clicked sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

        midi.ReplaySong();
        SoundManager.soundManager.MainMenuMusic.UnPause();
        SceneManager.LoadScene("MainMenu");
        Debug.Log("REPLAY");
    }

    public void PauseReplayClicked()
    {

        // play button clicked sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

        midi.ReplaySong();
        SceneManager.LoadScene("Play");
    }

    public void PauseSettingsClicked()
    {
        piano.SetActive(false);
        settingsPanel.SetActive(true);
        pianoBackground.SetActive(false);
        scoreText.gameObject.SetActive(false);
        progressSong.gameObject.SetActive(false);
        pauseManuPanel.SetActive(false);
        pauseBtn.gameObject.SetActive(false);

        settingsPanel.GetComponent<Settings>().StartupApplyButton();

        // play button clicked sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void PauseSettingBackButtonClicked()
    {
        piano.SetActive(true);
        settingsPanel.SetActive(false);
        pianoBackground.SetActive(true);
        scoreText.gameObject.SetActive(true);
        progressSong.gameObject.SetActive(true);
        pauseManuPanel.SetActive(true);
        pauseBtn.gameObject.SetActive(true);

        InitSettings();

        // play button clicked sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }


}
