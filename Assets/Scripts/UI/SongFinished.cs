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
    public PlayLogic Logic;

    public void UpdateText()
    {
        notesHitText.text = Logic.numNotesHit + "/" + Logic.numNotesTotal + " notes hit";
        float percent = Logic.numNotesHit / Logic.numNotesTotal;
        percentTrunk = Mathf.Round(percent * 100f) / 100f;
        percentageText.text = (percentTrunk * 100).ToString() + "%";
        UpdateUserScore();
    }

    public void mainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void replayButtonClicked()
    {
        SceneManager.LoadScene("Play");
    }

    void UpdateUserScore()
    {
        updatePercentage();
        UpdateStars();
        UpdateHighScore();
        UpdateNotesHit();
        UpdatePlays();

        // Save data
        PersistentData.SaveJsonData(PersistentData.data);
    }

    void updatePercentage()
    {

        if ((percentTrunk * 100) > PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage = (percentTrunk * 100);
            
        }
    }

    void UpdateStars()
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

    void UpdateHighScore()
    {
        if (Logic.currentScore > PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._highScore)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._highScore = Logic.currentScore;

        }
    }

    void UpdateNotesHit()
    {
        if (Logic.numNotesHit > PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._notesHit)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._notesHit = (int)Logic.numNotesHit;
        }
    }

    void UpdatePlays()
    {
        PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._plays += 1;
    }

}
