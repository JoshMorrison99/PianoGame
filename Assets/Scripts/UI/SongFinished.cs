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

        if ((percentTrunk * 100) > PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage = (percentTrunk * 100);
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._notesHit = (int) playSongLogic.numNotesHit;

            calculateStars();
        }
    }

    void calculateStars()
    {
        if ((percentTrunk * 100) < 25)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "*";
        }else if ((percentTrunk * 100) > 25 && (percentTrunk * 100) < 50)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* *";
        }else if ((percentTrunk * 100) > 50 && (percentTrunk * 100) < 75)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * *";
        }else if ((percentTrunk * 100) > 75 && (percentTrunk * 100) < 95)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * * *";
        }else if ((percentTrunk * 100) > 95)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * * * *";
        }
    }

}
