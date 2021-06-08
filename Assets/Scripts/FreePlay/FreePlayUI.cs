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

    private void Start()
    {
        PausePanel.SetActive(false);
        PauseButton.gameObject.SetActive(true);

        DeviceFinder.device.GetPianoDeviceErrorText();
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



}
