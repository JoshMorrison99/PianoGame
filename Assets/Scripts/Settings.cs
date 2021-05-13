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

    // Display Quality
    public int currentQualityIndex = 0;
    public Button LeftQualityButton;
    public Button RightQualityButton;
    public TextMeshProUGUI qualityText;
    public string[] qualityOptions = new string[] { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };

    // Apply
    public GameObject ApplySettingsPanel;
    public Button ApplyYESButon;
    public Button ApplyNOButton;

    // Reset 
    public GameObject ResetSettingPanel;
    public GameObject ResetPanel;
    public Button Reset_YES_button;
    public Button Reset_NO_button;

    // Language
    public TMP_Dropdown languageDropdown;
    public List<string> languages = new List<string>();

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
        GetInputDevices();
        GetDeviceResolutions();
        LoadSettings();
        SetupLanguageDropdown();
        StartupResetSettings();
        StartupApplyButton();
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

    public void GetInputDevices()
    {
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            KeyboardSelect.AddOptions(new List<string> { device.displayName } );
            KeyboardSelect.itemText.font = Resources.Load("Roboto-Regular SDF") as TMP_FontAsset;
        }

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            KeyboardSelect.AddOptions(new List<string> { device.displayName });
            KeyboardSelect.itemText.font = Resources.Load("Roboto-Regular SDF") as TMP_FontAsset;

        };

    }

    public void LanguageDropdownChanged(TMP_Dropdown dropdownElement)
    {
        int index = dropdownElement.value;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void SetupLanguageDropdown()
    {
        Debug.Log("SETUP LANGUAGE DROPDOWN");
        languages.Add("English");
        languages.Add("French");
        languages.Add("Spanish");

        TMP_Dropdown myDropdown = languageDropdown.GetComponent<TMP_Dropdown>();
        myDropdown.RefreshShownValue();


        myDropdown.options.Clear();

        foreach (var language in languages)
        {
            myDropdown.options.Add(new TMP_Dropdown.OptionData() { text = language});
            myDropdown.itemText.font = Resources.Load("Roboto-Regular SDF") as TMP_FontAsset;
            //Debug.Log("Adding Option: " + language);
        }

        myDropdown.RefreshShownValue();
        myDropdown.onValueChanged.AddListener(delegate { LanguageDropdownChanged(languageDropdown); });

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
        ON_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

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
        ON_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

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
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Turn off Note labels by default
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Turn off pinao labels by default
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Turn on key press labels by default
        ON_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_KeyPressLabel.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

        // Sound volume at 50% by default
        MasterVolume.value = 0.5f;

        if (SceneManager.GetActiveScene().name == "MainMenu") {
            // Playback speed set to 100% by default
            speedSlider.value = 1f;
        }


       
    }

    public void LeftButtonChangeQuality()
    {
        if (currentQualityIndex == 0)
        {
            currentQualityIndex = qualityOptions.Length - 1;
            QualitySettings.SetQualityLevel(currentQualityIndex, false);
            qualityText.text = "Quality " + qualityOptions[currentQualityIndex];
        }else if (currentQualityIndex > 0)
        {
            currentQualityIndex -= 1;
            QualitySettings.SetQualityLevel(currentQualityIndex, false);
            qualityText.text = "Quality " + qualityOptions[currentQualityIndex];
        }

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

    public void RightButtonChangeQuality()
    {
        if (currentQualityIndex == qualityOptions.Length - 1)
        {
            currentQualityIndex = 0;
            QualitySettings.SetQualityLevel(currentQualityIndex, false);
            qualityText.text = "Quality " + qualityOptions[currentQualityIndex];
        }
        else if (currentQualityIndex < qualityOptions.Length - 1)
        {
            currentQualityIndex += 1;
            QualitySettings.SetQualityLevel(currentQualityIndex, false);
            qualityText.text = "Quality " + qualityOptions[currentQualityIndex];
        }

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
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
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

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
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

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
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

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
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

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
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

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
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

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

        // Play button clicked SFX
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }
    }

}
