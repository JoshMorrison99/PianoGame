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


    public PlayLogic playSongLogic;

    public void UpdateText()
    {
        notesHitText.text = playSongLogic.numNotesHit + "/" + playSongLogic.numNotesTotal + " notes hit";
        float percent = playSongLogic.numNotesHit / playSongLogic.numNotesTotal;
        float percentTrunk = Mathf.Round(percent * 100f) / 100f;
        percentageText.text = (percentTrunk * 100).ToString() + "%";
    }

    public void mainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replayButtonClicked()
    {
        SceneManager.LoadScene("Play");
    }


}
