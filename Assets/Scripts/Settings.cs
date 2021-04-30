using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;

public class Settings : MonoBehaviour
{

    // Language
    public TMP_Dropdown languageDropdown;

    // Gameplay
    const string speed_Pref = "Speed";
    public Slider speedSlider;

    // Audio
    const string volume_Pref = "Volume";

    // Video
    const string pianoLabel_Pref = "isPianoLabelled";
    const string noteLabel_Pref = "isNoteLabelled";
    const string vfx_Pref = "isVFX";
    public int isPianoLabelled = 1;
    public int isNoteLabelled = 1;
    public int isVFX = 1;

    public Slider MasterVolume;
    public Button ON_Button_VFX;
    public Button OFF_Button_VFX;
    public Button ON_Button_NoteLabels;
    public Button OFF_Button_NoteLabels;
    public Button ON_Button_PianoLabels;
    public Button OFF_Button_PianoLabels;
    public TMP_Dropdown KeyboardSelect;

    // Windowed Mode Settings
    public Button LeftWindowedButton;
    public Button RightWindowedButton;
    public TextMeshProUGUI WindowedText;
    public string[] screenModes = new string[] { "Fullscreen", "Windowed", "Maximized" };
    public int screenModesIndex;
    const string screenMode_Pref = "screenMode";

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
        GetInputDevices();
        GetDeviceResolutions();
        LoadSettings();
    }

    public void GetDeviceResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionOptions = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
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

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(volume_Pref, MasterVolume.value);
        PlayerPrefs.SetFloat(speed_Pref, speedSlider.value);
        PlayerPrefs.SetInt(pianoLabel_Pref, isPianoLabelled);
        PlayerPrefs.SetInt(noteLabel_Pref, isNoteLabelled);
        PlayerPrefs.SetInt(vfx_Pref, isVFX);

        // Save Windowed Mode Setting
        PlayerPrefs.SetString(screenMode_Pref, screenModes[screenModesIndex]);
        SetWindowedSetting();

        // Save Resolution Setting
        PlayerPrefs.SetString(resolution_Pref, resolutionOptions[resolutionIndex]);
        SetResolutionSetting();
    }

    public void LoadSettings()
    {
        MasterVolume.value = PlayerPrefs.GetFloat(volume_Pref);
        speedSlider.value = PlayerPrefs.GetFloat(speed_Pref);
        isPianoLabelled = PlayerPrefs.GetInt(pianoLabel_Pref);
        isNoteLabelled = PlayerPrefs.GetInt(noteLabel_Pref);
        isVFX = PlayerPrefs.GetInt(vfx_Pref);

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

        // Load the screen windowed setting text
        WindowedText.text = PlayerPrefs.GetString(screenMode_Pref);

        // Load the screen resolution setting text
        ResolutionText.text = PlayerPrefs.GetString(resolution_Pref);
    }


    public void ApplyButtonPressed()
    {
        SaveSettings();
    }

    public void GetInputDevices()
    {
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            KeyboardSelect.AddOptions(new List<string> { device.displayName } );
        }

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            KeyboardSelect.AddOptions(new List<string> { device.displayName });

        };

    }

    public void LanguageDropdownChanged(TMP_Dropdown dropdownElement)
    {
        int index = dropdownElement.value;

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void PlayScene_BackButtonPressed(GameObject pauseMenu)
    {
        SaveSettings();
        pauseMenu.GetComponent<PlayUILogic>().PauseSettingBackButtonClicked();
    }



    public void VolumeSliderChangedValue()
    {
        float volumeValue = MasterVolume.value;
        PlayerPrefs.SetFloat(volume_Pref, volumeValue);
    }

    public void SpeedSliderChangedValue()
    {
        float speedValue = speedSlider.value;
        PlayerPrefs.SetFloat(speed_Pref, speedValue);
    }

    public void ResetButtonPressed() // Restore all options to default
    {
        PlayerPrefs.SetInt(pianoLabel_Pref, 1); // Trun on pinao labels by default
        PlayerPrefs.SetInt(noteLabel_Pref, 0); // Turn off Note labels by default
        PlayerPrefs.SetInt(vfx_Pref, 0); // Turn off vfx by default
        PlayerPrefs.SetFloat(volume_Pref, 0.5f); // Sound volume at 50% by default
        PlayerPrefs.SetFloat(speed_Pref, 1f); // speed at 100% by default

        ResetButtonPressedUI();
    }

    public void BackButtonPressed()
    {
        SaveSettings();
    }

    public void ResetButtonPressedUI() // Restore all options to default UI
    {
        // Turn off VFX by default
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Turn off Note labels by default
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Trun on pinao labels by default
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

        // Sound volume at 50% by default
        MasterVolume.value = 0.5f;

        // Playback speed set to 100% by default
        speedSlider.value = 1f;
    }

    public void SetResolutionSetting()
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); 
    }

    public void SetWindowedSetting()
    {
        if (screenModesIndex == 0)
        {
            Screen.fullScreen = true;
        }else if (screenModesIndex == 1)
        {
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }else if (screenModesIndex == 2)
        {
            Screen.fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }
    }

    public void VFX_ON_Clicked()
    {
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

        // Update player prefs
        isVFX = 1;
    }

    public void VFX_OFF_Clicked()
    {
        ON_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_VFX.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Update player prefs
        isVFX = 0;
    }

    public void NoteLabel_ON_Clicked()
    {
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

        // Update player prefs
        isNoteLabelled = 1;
    }

    public void NoteLabel_OFF_Clicked()
    {
        ON_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_NoteLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Update player prefs
        isNoteLabelled = 0;
    }

    public void PianoLabel_ON_Clicked()
    {
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;

        // Update player prefs
        isPianoLabelled = 1;
    }
    public void PianoLabel_OFF_Clicked()
    {
        ON_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.GRAY;
        OFF_Button_PianoLabels.GetComponent<Image>().color = COLOR_PALLETE.LIGHT_BLUE;

        // Update player prefs
        isPianoLabelled = 0;
    }

    public void LeftWindowedButtonClicked()
    {
        screenModesIndex -= 1;
        if (screenModesIndex < 0)
        {
            screenModesIndex = 2;
        }

        WindowedText.text = screenModes[screenModesIndex];

        Debug.Log(screenModesIndex);

    }
    public void RightWindowedButtonClicked()
    {
        screenModesIndex += 1;
        if (screenModesIndex > 2)
        {
            screenModesIndex = 0;
        }

        WindowedText.text = screenModes[screenModesIndex];

        Debug.Log(screenModesIndex);
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
    }
}
