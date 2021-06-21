using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class PlayUILogic : MonoBehaviour
{

    public delegate void ButtonClickedAction();
    public static event ButtonClickedAction buttonClickedEvent;

    public PlayLogic Logic;

    public MidiMagic midi;

    public GameObject Timeline;

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

    public GameObject SongTitleBanner;
    public TextMeshProUGUI SongTitleBannerText;


    public int songPercentage;

    // PIANO BAR VIDEO
    public VideoPlayer pianoBarVideo;

    // Start is called before the first frame update
    void Start()
    {
        if (PersistentData.data.TimelineActivate)
        {
            Timeline.SetActive(true);
        }
        else
        {
            Timeline.SetActive(false);
        }

        SetPianoUI();

        DeviceFinder deviceFinder = GameObject.Find("DeviceFinder").GetComponent<DeviceFinder>();
        deviceFinder.GetPianoDeviceErrorText();

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();

        isPaused = false;
        ActivateGame();

        SongTitleBanner.SetActive(true);
        SongTitleBannerText.text = PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._SongTitle;
        StartCoroutine(SongBannerAnim());

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

        // Set piano bar color
        if (PersistentData.data.ThemePianoBar == null)
        {
            pianoBarVideo.gameObject.SetActive(false);
        }
        else
        {
            pianoBarVideo.clip = PersistentData.data.ThemePianoBar;
        }
        
        // Disable the slider for playback speed so the user cannot change the speed while playing
        speedSlider.enabled = false;
    }

    IEnumerator SongBannerAnim()
    {
        yield return new WaitForSeconds(1);
        SongTitleBanner.LeanScaleY(0, 0.5f).setEaseInOutSine();
    }

    public void SetPianoUI()
    {
        if (PlayerPrefs.GetInt("PianoType") == 0) // 49 key piano
        {
            piano.transform.localPosition = new Vector3(5.65f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(21.2f, piano.transform.localScale.y, piano.transform.localScale.z);

            pianoKeyLabels.transform.localPosition = new Vector3(196.5f, pianoKeyLabels.transform.localPosition.y, pianoKeyLabels.transform.localPosition.z);
            pianoKeyLabels.transform.localScale = new Vector3(1.21f, pianoKeyLabels.transform.localScale.y, pianoKeyLabels.transform.localScale.z);
        }
        else if (PlayerPrefs.GetInt("PianoType") == 1) // 61 key piano
        {
            piano.transform.localPosition = new Vector3(2.84f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(17f, piano.transform.localScale.y, piano.transform.localScale.z);

            pianoKeyLabels.transform.localPosition = new Vector3(-23.5f, pianoKeyLabels.transform.localPosition.y, pianoKeyLabels.transform.localPosition.z);
            pianoKeyLabels.transform.localScale = new Vector3(0.97f, pianoKeyLabels.transform.localScale.y, pianoKeyLabels.transform.localScale.z);
        }
        else if (PlayerPrefs.GetInt("PianoType") == 2) // 76 key piano
        {
            piano.transform.localPosition = new Vector3(2.48f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(13.6f, piano.transform.localScale.y, piano.transform.localScale.z);

            pianoKeyLabels.transform.localPosition = new Vector3(4.15f, pianoKeyLabels.transform.localPosition.y, pianoKeyLabels.transform.localPosition.z);
            pianoKeyLabels.transform.localScale = new Vector3(0.775f, pianoKeyLabels.transform.localScale.y, pianoKeyLabels.transform.localScale.z);
        }
        else
        {
            Debug.Log("Error occured getting piano type UI");
        }
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
        Time.timeScale = 1;
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
        pianoBarVideo.gameObject.SetActive(false);
        settingsPanel.GetComponent<Settings>().StartupApplyButton();
        pianoKeyLabels.SetActive(false);

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
        pianoBarVideo.gameObject.SetActive(true);

        if (PlayerPrefs.GetFloat("isPianoLabelled") == 1)
        {
            pianoKeyLabels.SetActive(true);
        }

        InitSettings();

        // play button clicked sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }


}
