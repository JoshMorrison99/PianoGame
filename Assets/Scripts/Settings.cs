using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    // Input
    // - Not sure if you can realy save anything here

    // Audio
    const string volume_Pref = "Volume";
    public Slider volumeSlider;

    // Video
    const string pianoLabel_Pref = "isPianoLabelled";
    const string noteLabel_Pref = "isNoteLabelled";
    const string vfx_Pref = "isVFX";
    public Button isPianoLabelledButton;
    public Button isNoteLabelledButton;
    public Button isVFXButton;
    public int isPianoLabelled = 1;
    public int isNoteLabelled = 1;
    public int isVFX = 1;


    // --------------Buttons Panels------------------
    public GameObject InputButtonPanel;
    public GameObject videoButtonPanel;
    public GameObject LanguageButtonPanel;
    public GameObject AudioButtonPanel;
    // ---------------------------------------
    public Button ApplyButton;
    public Button ResetButton;
    // ---------------------------------------
    public bool isInputPanelOn;
    public bool isVideoPanelOn;
    public bool isLanguagePanelOn;
    public bool isAudioPanelOn;
    // ---------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        
        InputButtonPressed();
        LoadSettings();
    }

    private void OnApplicationQuit()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(volume_Pref, volumeSlider.value);
        PlayerPrefs.SetInt(pianoLabel_Pref, isPianoLabelled);
        PlayerPrefs.SetInt(noteLabel_Pref, isNoteLabelled);
        PlayerPrefs.SetInt(vfx_Pref, isVFX);
    }

    public void LoadSettings()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(volume_Pref);

        isPianoLabelled = PlayerPrefs.GetInt(pianoLabel_Pref);
        isNoteLabelled = PlayerPrefs.GetInt(noteLabel_Pref);
        isVFX = PlayerPrefs.GetInt(vfx_Pref);

        // Video Button UI
        GetVideoLabels();

    }

    public void InputButtonPressed()
    {
        isInputPanelOn = true;
        isAudioPanelOn = false;
        isLanguagePanelOn = false;
        isVideoPanelOn = false; 

        InputButtonPanel.SetActive(true);
        videoButtonPanel.SetActive(false);
        LanguageButtonPanel.SetActive(false);
        AudioButtonPanel.SetActive(false);
    }

    public void VideoButtonPressed()
    {
        isInputPanelOn = false;
        isAudioPanelOn = false;
        isLanguagePanelOn = false;
        isVideoPanelOn = true;

        InputButtonPanel.SetActive(false);
        videoButtonPanel.SetActive(true);
        LanguageButtonPanel.SetActive(false);
        AudioButtonPanel.SetActive(false);
    }

    public void LangugaeButtonPressed()
    {
        isInputPanelOn = false;
        isAudioPanelOn = false;
        isLanguagePanelOn = true;
        isVideoPanelOn = false;

        InputButtonPanel.SetActive(false);
        videoButtonPanel.SetActive(false);
        LanguageButtonPanel.SetActive(true);
        AudioButtonPanel.SetActive(false);
    }

    public void AudioButtonPressed()
    {
        isInputPanelOn = false;
        isAudioPanelOn = true;
        isLanguagePanelOn = false;
        isVideoPanelOn = false;

        InputButtonPanel.SetActive(false);
        videoButtonPanel.SetActive(false);
        LanguageButtonPanel.SetActive(false);
        AudioButtonPanel.SetActive(true);
    }

    public void PianoLabelledButtonPressed()
    {
        if (PlayerPrefs.GetInt(pianoLabel_Pref) == 0)
        {
            PlayerPrefs.SetInt(pianoLabel_Pref, 1);
            isPianoLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Piano Labelled: Yes";
            isPianoLabelled = 1;
        }
        else
        {
            PlayerPrefs.SetInt(pianoLabel_Pref, 0);
            isPianoLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Piano Labelled: No";
            isPianoLabelled = 0;
        }
    }

    public void GetVideoLabels()
    {
        if (PlayerPrefs.GetInt(pianoLabel_Pref) == 1)
        {
            isPianoLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Piano Labelled: Yes";
        }
        else
        {
            isPianoLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Piano Labelled: No";
        }

        if (PlayerPrefs.GetInt(noteLabel_Pref) == 1)
        {
            isNoteLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Note Labelled: Yes";
        }
        else
        {
            isNoteLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Note Labelled: No";
        }

        if (PlayerPrefs.GetInt(vfx_Pref) == 1)
        {
            isVFXButton.GetComponentInChildren<TextMeshProUGUI>().text = "VFX: Yes";
        }
        else
        {
            isVFXButton.GetComponentInChildren<TextMeshProUGUI>().text = "VFX: No";
        }
    }

    public void NoteLabelledButtonPressed()
    {
        if (PlayerPrefs.GetInt(noteLabel_Pref) == 0)
        {
            PlayerPrefs.SetInt(noteLabel_Pref, 1);
            isNoteLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Note Labelled: Yes";
            isNoteLabelled = 1;
        }
        else
        {
            PlayerPrefs.SetInt(noteLabel_Pref, 0);
            isNoteLabelledButton.GetComponentInChildren<TextMeshProUGUI>().text = "Note Labelled: No";
            isNoteLabelled = 0;
        }
    }

    public void VFXButtonPressed()
    {
        if (PlayerPrefs.GetInt(vfx_Pref) == 0)
        {
            PlayerPrefs.SetInt(vfx_Pref, 1);
            isVFXButton.GetComponentInChildren<TextMeshProUGUI>().text = "VFX: Yes";
            isVFX = 1;
        }
        else
        {
            PlayerPrefs.SetInt(vfx_Pref, 0);
            isVFXButton.GetComponentInChildren<TextMeshProUGUI>().text = "VFX: No";
            isVFX = 0;
        }
    }

    public void ApplyButtonPressed()
    {
        SaveSettings();
    }

    public void ResetButtonPressed()
    {
        if (isInputPanelOn)
        {
               
        }
        else if (isVideoPanelOn)
        {
            isVFX = 1;
            isPianoLabelled = 1;
            isNoteLabelled = 1;

            PlayerPrefs.SetInt(pianoLabel_Pref, isPianoLabelled);
            PlayerPrefs.SetInt(noteLabel_Pref, isNoteLabelled);
            PlayerPrefs.SetInt(vfx_Pref, isVFX);

            GetVideoLabels();
        }
        else if (isLanguagePanelOn)
        {

        }
        else if (isAudioPanelOn)
        {
            PlayerPrefs.SetFloat(volume_Pref, 0.5f);

            // Reset UI
            volumeSlider.value = PlayerPrefs.GetFloat(volume_Pref);
        }
    }
}
