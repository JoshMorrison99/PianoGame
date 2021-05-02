using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SongFinished : MonoBehaviour
{
    // level system ui
    public TextMeshProUGUI levelTextStart;
    public TextMeshProUGUI levelTextNext;
    public TextMeshProUGUI moneyNotesText;
    public TextMeshProUGUI levelTextBig;
    public Slider levelSlider;

    // Stars ui
    public Image star1;
    public Image star2;
    public Image star3;
    public Image star4;
    public Image star5;


    public TextMeshProUGUI percentageText;
    public TextMeshProUGUI notesHitText;
    public Button replaySongBtn;
    public Button mainMenuBtn;

    public MidiMagic midi;
    

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
        midi.ReplaySong();
        SceneManager.LoadScene("MainMenu");
    }

    public void replayButtonClicked()
    {
        midi.ReplaySong();
        SceneManager.LoadScene("Play");
    }

    void UpdateUserScore()
    {
        updatePercentage();
        UpdateStars();
        UpdateHighScore();
        UpdateNotesHit();
        UpdatePlays();
        

        LevelUp();
        UpdateUserMoney();
        UpdateUserMoneyUI();
        SetUserLevel();
        UpdateExpBar();

        // Save data
        PersistentData.SaveJsonData(PersistentData.data);
    }

    void updatePercentage()
    {
        Debug.Log((percentTrunk * 100));
        Debug.Log(PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage);
        Debug.Log(PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._SongTitle);

        if ((percentTrunk * 100) > PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._songCompletionPercentage = (percentTrunk * 100);
            
        }
    }

    public void SetUserLevel()
    {
        levelTextBig.text = "Level: " + PersistentData.data.level;
    }

    public void UpdateExpBar()
    {
        levelTextStart.text = PersistentData.data.exp.ToString();
        levelTextNext.text = "Next: " + ReturnXPNeededToLevelUp(PersistentData.data.level);
        levelSlider.value = PersistentData.data.exp / ReturnXPNeededToLevelUp(PersistentData.data.level);
    }

    public void UpdateUserMoneyUI()
    {
        moneyNotesText.text = PersistentData.data.money.ToString();
    }

    void UpdateStars()
    {
        if ((percentTrunk * 100) < 25)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "*";
            OneStar();
        }else if ((percentTrunk * 100) > 25 && (percentTrunk * 100) < 50)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* *";
            TwoStar();
        }else if ((percentTrunk * 100) > 50 && (percentTrunk * 100) < 75)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * *";
            ThreeStar();
        }else if ((percentTrunk * 100) > 75 && (percentTrunk * 100) < 95)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * * *";
            FourStar();
        }else if ((percentTrunk * 100) > 95)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * * * *";
            FiveStar();
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

    int ReturnXPNeededToLevelUp(int level)
    {
        return (int) Mathf.Round((10 * (Mathf.Pow(level, 3))) / 5);
    }

   

    public void LevelUp()
    {
        while (PersistentData.data.exp > ReturnXPNeededToLevelUp(PersistentData.data.level))
        {
            Debug.Log(PersistentData.data.exp);
            Debug.Log(ReturnXPNeededToLevelUp(PersistentData.data.level));
            PersistentData.data.exp = PersistentData.data.exp - ReturnXPNeededToLevelUp(PersistentData.data.level); 
            PersistentData.data.level += 1;
        }
    }

    public void UpdateUserMoney()
    {
        PersistentData.data.money += (int) Logic.numNotesHit;
    }

    public void HideStars()
    {
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        star4.gameObject.SetActive(false);
        star5.gameObject.SetActive(false);
    }

    public void OneStar()
    {
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        star4.gameObject.SetActive(false);
        star5.gameObject.SetActive(false);
    }

    public void TwoStar()
    {
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(false);
        star4.gameObject.SetActive(false);
        star5.gameObject.SetActive(false);
    }

    public void ThreeStar()
    {
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(true);
        star4.gameObject.SetActive(false);
        star5.gameObject.SetActive(false);
    }

    public void FourStar()
    {
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(true);
        star4.gameObject.SetActive(true);
        star5.gameObject.SetActive(false);
    }

    public void FiveStar()
    {
        star1.gameObject.SetActive(true);
        star2.gameObject.SetActive(true);
        star3.gameObject.SetActive(true);
        star4.gameObject.SetActive(true);
        star5.gameObject.SetActive(true);
    }

}
