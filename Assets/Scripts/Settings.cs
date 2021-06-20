using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class Settings : MonoBehaviour
{
    bool isFirstLoad = true;

    // Delegates
    public delegate void SettingsChangedAction();
    public static event SettingsChangedAction SettingsChanged;
    public delegate void ButtonClickedAction();
    public static event ButtonClickedAction buttonClickedEvent;

    // Main Menu
    public GameObject mainMenuTitle;
    public GameObject MainMenuThemesButton;
    public GameObject MainMenuMiniGamesButton;
    public GameObject MainMenuFreePlayButton;
    public GameObject MainMenuSelectionButton;
    public GameObject MainMenuSettingsButton;
    public GameObject MainMenuAccountButton;
    public GameObject MainMenuQuitButton;

    // Apply
    public GameObject ApplySettingsPanel;
    public Button ApplyYESButon;
    public Button ApplyNOButton;

    // Reset 
    public GameObject ResetSettingPanel;
    public GameObject ResetPanel;
    public Button Reset_YES_button;
    public Button Reset_NO_button;

    // Gameplay
    const string speed_Pref = "Speed";
    public Slider speedSlider;

    // Audio
    const string volume_Pref = "Volume";

    // Video
    const string pianoLabel_Pref = "isPianoLabelled";
    const string noteLabel_Pref = "isNoteLabelled";
    const string vfx_Pref = "isVFX";
    const string keyPress_Pref = "isKeyPressLabel";
    public int isPianoLabelled = 1;
    public int isNoteLabelled = 1;
    public int isVFX = 1;
    public int isKeyPressLabel = 1;

    // Save start settings
    public int start_pianoLabel;
    public int start_noteLabel;
    public int start_vfx;
    public int start_keyPress;
    public float start_volume;
    public float start_speed;

    public Slider MasterVolume;
    public Button ON_Button_VFX;
    public Button OFF_Button_VFX;
    public Button ON_Button_NoteLabels;
    public Button OFF_Button_NoteLabels;
    public Button ON_Button_PianoLabels;
    public Button OFF_Button_PianoLabels;
    public Button ON_Button_KeyPressLabel;
    public Button OFF_Button_KeyPressLabel;
    public TMP_Dropdown KeyboardSelect;

    // Windowed Mode Settings
    public Button LeftWindowedButton;
    public Button RightWindowedButton;
    public TextMeshProUGUI WindowedText;
    public string[] screenModes = new string[] { "Fullscreen", "Windowed"};
    public int screenModesIndex;
    const string screenMode_Pref = "screenMode";
    public bool isFullScreen;

    // Resolution Mode Settings
    public Button LeftResolutionButton;
    public Button RightResolutionButton;
    public TextMeshProUGUI ResolutionText;
    Resolution[] resolutions;
    List<string> resolutionOptions;
    int resolutionIndex = 0;
    const string resolution_Pref = "resolution";

    // ---------------------------------------
    public Button ApplyButton;
    public Button ResetButton;
    public Button BackButton;
    // ---------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        isFirstLoad = true;
        Debug.Log("Start......................................");
        GetDeviceResolutions();
        LoadSettings();
        StartupResetSettings();
        StartupApplyButton();
        SaveStartSettings();
    }

    public void GetDeviceResolutions()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionOptions = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                resolutionIndex = i;
            }
        }

        ResolutionText.text = resolutionOptions[resolutionIndex];
    }

    private void OnApplicationQuit()
    {
        SaveSettings();
    }

    public void StartupResetSettings()
    {
        ResetSettingPanel.SetActive(false);
    }

    public void StartupApplyButton()
    {
        ApplyButton.gameObject.SetActive(false);
        ApplySettingsPanel.SetActive(false);
    }

   

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(volume_Pref, MasterVolume.value);
        PlayerPrefs.SetFloat(speed_Pref, speedSlider.value);
        PlayerPrefs.SetInt(pianoLabel_Pref, isPianoLabelled);
        PlayerPrefs.SetInt(noteLabel_Pref, isNoteLabelled);
        PlayerPrefs.SetInt(vfx_Pref, isVFX);
        PlayerPrefs.SetInt(keyPress_Pref, isKeyPressLabel);

        // Save Windowed Mode Setting
        PlayerPrefs.SetString(screenMode_Pref, screenModes[screenModesIndex]);
        SetWindowedSetting();

        // Save Resolution Setting
        PlayerPrefs.SetString(resolution_Pref, resolutionOptions[resolutionIndex]);
        SetResolutionSetting();

        // Dispatch event to listeners (the only listener is the display note right now)
        if (SettingsChanged != null)
        {
            SettingsChanged();
        }
    }

    public void SaveStartSettings()
    {
        start_volume = PlayerPrefs.GetFloat(volume_Pref);
        start_speed = PlayerPrefs.GetFloat(speed_Pref);
        start_pianoLabel = PlayerPrefs.GetInt(pianoLabel_Pref);
        start_pianoLabel = PlayerPrefs.GetInt(noteLabel_Pref);
        start_vfx = PlayerPrefs.GetInt(vfx_Pref);
        start_keyPress = PlayerPrefs.GetInt(keyPress_Pref);
    }

    public void LoadSettings()
    {
        MasterVolume.value = PlayerPrefs.GetFloat(volume_Pref);
        speedSlider.value = PlayerPrefs.GetFloat(speed_Pref);
        isPianoLabelled = PlayerPrefs.GetInt(pianoLabel_Pref);
        isNoteLabelled = PlayerPrefs.GetInt(noteLabel_Pref);
        isVFX = PlayerPrefs.GetInt(vfx_Pref);
        isKeyPressLabel = PlayerPrefs.GetInt(keyPress_Pref);

        // Set the UI for VFX buttons
        if (isVFX == 0)
        {
            VFX_OFF_Clicked();
        }
        else
        {
            VFX_ON_Clicked();
        }

        // set the UI for note label buttons
        if (isNoteLabelled == 0)
        {
            NoteLabel_OFF_Clicked();
        }
        else
        {
            NoteLabel_ON_Clicked();
        }

        // Set the UI for paino label buttons
        if (isPianoLabelled == 0)
        {
            PianoLabel_OFF_Clicked();
        }
        else
        {
            PianoLabel_ON_Clicked();
        }

        // Set the UI for the key press label button
        if (isKeyPressLabel == 0)
        {
            KeyPressLabel_OFF_Clicked();
        }
        else
        {
            KeyPressLabel_ON_Clicked();
        }

        isFirstLoad = false;

        // Load the screen windowed setting text
        WindowedText.text = PlayerPrefs.GetString(screenMode_Pref);

        // Load the screen resolution setting text
        ResolutionText.text = PlayerPrefs.GetString(resolution_Pref);
    }


    public void ApplyButtonPressed()
    {
        SaveSettings();
        ApplyButton.gameObject.SetActive(false);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    
    public void PlayScene_BackButtonPressed(GameObject pauseMenu)
    {
        if (ApplyButton.IsActive() == false)
        {
            pauseMenu.GetComponent<PlayUILogic>().PauseSettingBackButtonClicked();
        }
        else
        {
            ApplySettingsPanel.SetActive(true);
        }

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

    }



    public void VolumeSliderChangedValue()
    {
        float volumeValue = MasterVolume.value;
        PlayerPrefs.SetFloat(volume_Pref, volumeValue);

        // Show apply button so the user can see that they can save their settings. 
        ApplyButton.gameObject.SetActive(true);
    }

    public void SpeedSliderChangedValue()
    {
        float speedValue = speedSlider.value;
        PlayerPrefs.SetFloat(speed_Pref, speedValue);

        // Show apply button so the user can see that they can save their settings. 
        ApplyButton.gameObject.SetActive(true);
    }

    public void ResetButtonPressed()
    {
        ResetSettingPanel.SetActive(true);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void BackButtonPressed()
    {
        if (ApplyButton.IsActive() == false)
        {
            this.gameObject.SetActive(false);
            mainMenuTitle.SetActive(true);
            MainMenuThemesButton.SetActive(true);
            MainMenuMiniGamesButton.SetActive(true);
            MainMenuFreePlayButton.SetActive(true);
            MainMenuSelectionButton.SetActive(true);
            MainMenuSettingsButton.SetActive(true);
            MainMenuAccountButton.SetActive(true);
            MainMenuQuitButton.SetActive(true);
            
        }
        else
        {
            ApplySettingsPanel.SetActive(true);
        }

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

    }

    public void KeyPressLabel_ON_Clicked()
    {
        // Change UI Color
        ON_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.ON;
        OFF_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.OFF;

        // Apply button logic
        if (isKeyPressLabel == 0)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isKeyPressLabel = 1;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }

    public void KeyPressLabel_OFF_Clicked()
    {
        // Change UI Color
        ON_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Apply button logic
        if (isKeyPressLabel == 1)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isKeyPressLabel = 0;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }



    public void ResetButtonPressedUI() // Restore all options to default UI
    {
        // Turn off VFX by default
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Turn off Note labels by default
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Turn off pinao labels by default
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Turn on key press labels by default
        ON_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.ON;
        OFF_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.OFF;

        // Sound volume at 50% by default
        MasterVolume.value = 0.5f;

        if (SceneManager.GetActiveScene().name == "MainMenu") {
            // Playback speed set to 100% by default
            speedSlider.value = 1f;
        }


       
    }


    public void SetResolutionSetting()
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, isFullScreen); 
    }

    public void SetWindowedSetting()
    {
        Debug.Log(screenModesIndex);
        if (screenModesIndex == 0)
        {
            isFullScreen = true;
            Screen.fullScreen = isFullScreen;
        }else
        {
            isFullScreen = false;
            Screen.fullScreen = isFullScreen;
            //Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void VFX_ON_Clicked()
    {
        // Change UI Color
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.ON;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.OFF;

        // Apply button logic
        if (isVFX == 0)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isVFX = 1;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }

    public void VFX_OFF_Clicked()
    {
        // Change UI Color
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Apply button logic
        if (isVFX == 1)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isVFX = 0;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }

    public void NoteLabel_ON_Clicked()
    {
        // Change UI Color
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.ON;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.OFF;

        // Apply button logic
        if (isNoteLabelled == 0)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isNoteLabelled = 1;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }

    public void NoteLabel_OFF_Clicked()
    {
        // Change UI Color
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Apply button logic
        if (isNoteLabelled == 1)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isNoteLabelled = 0;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }

    public void PianoLabel_ON_Clicked()
    {
        // Change UI Color
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.ON;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.OFF;

        // Apply button logic
        if (isPianoLabelled == 0)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isPianoLabelled = 1;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }
    public void PianoLabel_OFF_Clicked()
    {
        // Change UI Color
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.OFF;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.ON;

        // Apply button logic
        if (isPianoLabelled == 1)
        {
            // Show apply button so the user can see that they can save their settings. 
            ApplyButton.gameObject.SetActive(true);
        }

        // Update player prefs
        isPianoLabelled = 0;

        // Play button clicked SFX
        if (buttonClickedEvent != null && isFirstLoad == false)
        {
            buttonClickedEvent();
        }
    }

    public void LeftWindowedButtonClicked()
    {
        if (screenModesIndex == 0)
        {
            screenModesIndex = 1;
        }
        else
        {
            screenModesIndex = 0;
        }

        WindowedText.text = screenModes[screenModesIndex];

        // Show apply button so the user can see that they can save their settings.
        ApplyButton.gameObject.SetActive(true);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

    }
    public void RightWindowedButtonClicked()
    {
        if (screenModesIndex == 1)
        {
            screenModesIndex = 0;
        }
        else
        {
            screenModesIndex = 1;
        }

        WindowedText.text = screenModes[screenModesIndex];

        // Show apply button so the user can see that they can save their settings. 
        ApplyButton.gameObject.SetActive(true);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void LeftResolutionButtonClicked()
    {
        Debug.Log(resolutionIndex);
        Debug.Log(resolutionOptions);
        resolutionIndex -= 1;
        if (resolutionIndex < 0)
        {
            resolutionIndex = resolutions.Length - 1;
        }

        ResolutionText.text = resolutionOptions[resolutionIndex];

        // Show apply button so the user can see that they can save their settings. 
        ApplyButton.gameObject.SetActive(true);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void RightResolutionButtonClicked()
    {
        Debug.Log(resolutionIndex);
        Debug.Log(resolutionOptions);
        resolutionIndex += 1;
        if (resolutionIndex > resolutions.Length - 1)
        {
            resolutionIndex = 0;
        }

        ResolutionText.text = resolutionOptions[resolutionIndex];

        // Show apply button so the user can see that they can save their settings.
        ApplyButton.gameObject.SetActive(true);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void ResetYESButtonPressed()
    {
        PlayerPrefs.SetInt(keyPress_Pref, 1); // Trun on key press labels by default
        isKeyPressLabel = 1;
        PlayerPrefs.SetInt(pianoLabel_Pref, 0); // Trun off pinao labels by default
        isPianoLabelled = 0;
        PlayerPrefs.SetInt(noteLabel_Pref, 0); // Turn off Note labels by default
        isNoteLabelled = 0;
        PlayerPrefs.SetInt(vfx_Pref, 0); // Turn off vfx by default
        isVFX = 0;
        PlayerPrefs.SetFloat(volume_Pref, 0.5f); // Sound volume at 50% by default

        if(SceneManager.GetActiveScene().name == "MainMenu")
            PlayerPrefs.SetFloat(speed_Pref, 1f); // speed at 100% by default

        ResetButtonPressedUI();

        ResetSettingPanel.SetActive(false);

        ApplyButton.gameObject.SetActive(false);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void ResetNOButtonPressed()
    {
        ResetSettingPanel.SetActive(false);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void ApplyYESButtonPressed()
    {
        SaveSettings();
        ApplySettingsPanel.SetActive(false);
        this.gameObject.SetActive(false);
        mainMenuTitle.SetActive(true);
        MainMenuThemesButton.SetActive(true);
        MainMenuMiniGamesButton.SetActive(true);
        MainMenuFreePlayButton.SetActive(true);
        MainMenuSelectionButton.SetActive(true);
        MainMenuSettingsButton.SetActive(true);
        MainMenuAccountButton.SetActive(true);
        MainMenuQuitButton.SetActive(true);

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void PlayScene_ApplyYESButtonPressed(GameObject pauseMenu)
    {
        SaveSettings();
        ApplySettingsPanel.SetActive(false);
        pauseMenu.GetComponent<PlayUILogic>().PauseSettingBackButtonClicked();

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void ApplyNOButtonPressed()
    {
        ApplySettingsPanel.SetActive(false);
        this.gameObject.SetActive(false);
        mainMenuTitle.SetActive(true);
        MainMenuThemesButton.SetActive(true);
        MainMenuMiniGamesButton.SetActive(true);
        MainMenuFreePlayButton.SetActive(true);
        MainMenuSelectionButton.SetActive(true);
        MainMenuSettingsButton.SetActive(true);
        MainMenuAccountButton.SetActive(true);
        MainMenuQuitButton.SetActive(true);

        MasterVolume.value = start_volume;
        speedSlider.value = start_speed;
        isVFX = start_vfx;
        isKeyPressLabel = start_keyPress;
        isPianoLabelled = start_pianoLabel;
        isNoteLabelled = start_noteLabel;

        LoadSettings();

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

}
