using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SongFinished : MonoBehaviour
{

    public TextMeshProUGUI percentageText;
    public TextMeshProUGUI notesHitText;
    public Button replaySongBtn;
    public Button mainMenuBtn;


    public void mainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replayButtonClicked()
    {
        SceneManager.LoadScene("Play");
    }


}
