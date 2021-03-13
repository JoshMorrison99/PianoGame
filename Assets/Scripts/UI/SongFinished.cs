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

    public float percentTrunk;
    public PlayLogic playSongLogic;

    public void UpdateText()
    {
        notesHitText.text = playSongLogic.numNotesHit + "/" + playSongLogic.numNotesTotal + " notes hit";
        float percent = playSongLogic.numNotesHit / playSongLogic.numNotesTotal;
        percentTrunk = Mathf.Round(percent * 100f) / 100f;
        percentageText.text = (percentTrunk * 100).ToString() + "%";
        updateUserScore();
    }

    public void mainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replayButtonClicked()
    {
        SceneManager.LoadScene("Play");
    }

    void updateUserScore()
    {
        if ((percentTrunk * 100) > PersistentData.data.song_Ode_To_Joy_Completion)
        {
            PersistentData.data.song_Ode_To_Joy_Completion = (percentTrunk * 100);
        }

        if ((percentTrunk * 100) > PersistentData.data.song_See_you_Again_Completion)
        {
            PersistentData.data.song_See_you_Again_Completion = (percentTrunk * 100);
        }
    }

}
