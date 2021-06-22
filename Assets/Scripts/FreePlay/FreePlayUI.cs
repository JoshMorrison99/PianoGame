using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class FreePlayUI : MonoBehaviour
{
    public GameObject PausePanel;
    public Button PauseButton;
    public TextMeshProUGUI ErrorText;
    public GameObject piano;


    private void Start()
    {
        PausePanel.SetActive(false);
        PauseButton.gameObject.SetActive(true);

        DeviceFinder.device.GetPianoDeviceErrorText();

        SetPianoUI();
    }

    public void PauseButtonClicked()
    {
        PausePanel.SetActive(true);
    }

    public void ResumeButtonClicked()
    {
        PausePanel.SetActive(false);
    }

    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetPianoUI()
    {
        if (PlayerPrefs.GetInt("PianoType") == 0) // 49 key piano
        {
            piano.transform.localPosition = new Vector3(1.4f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(21.2f, piano.transform.localScale.y, piano.transform.localScale.z);

        }
        else if (PlayerPrefs.GetInt("PianoType") == 1) // 61 key piano
        {
            piano.transform.localPosition = new Vector3(-0.6f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(17f, piano.transform.localScale.y, piano.transform.localScale.z);

        }
        else if (PlayerPrefs.GetInt("PianoType") == 2) // 76 key piano
        {
            piano.transform.localPosition = new Vector3(0.5f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(13.6f, piano.transform.localScale.y, piano.transform.localScale.z);

        }
        else
        {
            Debug.Log("Error occured getting piano type UI");
        }
    }

}
