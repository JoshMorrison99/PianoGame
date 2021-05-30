using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Video;

public class SongFinished : MonoBehaviour
{

    public delegate void LevelUpAction();
    public static event LevelUpAction LevelUpEvent;

    public delegate void LevellingUpAction();
    public static event LevellingUpAction LevellingUpEvent;

    public delegate void ButtonClickedAction();
    public static event ButtonClickedAction buttonClickedEvent;

    public VideoPlayer videoPlayer;
    public GameObject topBar;

    // level system ui
    public TextMeshProUGUI levelTextStart;
    public TextMeshProUGUI levelTextNext;
    public TextMeshProUGUI moneyNotesText;
    public TextMeshProUGUI levelTextBig;
    public Slider levelSlider;
    private float startExp;
    private float endExp;
    private int startLevel;
    private int endLevel;
    private float finalExp;

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

    private void Update()
    {
        if (PersistentData.data.isLevellingUp)
        {
            mainMenuBtn.enabled = false;
            replaySongBtn.enabled = false;
        }
        else
        {
            mainMenuBtn.enabled = true;
            replaySongBtn.enabled = true;
        }
    }

    public void mainMenuButtonClicked()
    {
        // play sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

        SoundManager.soundManager.MainMenuMusic.UnPause();
        midi.ReplaySong();
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }

    public void replayButtonClicked()
    {
        // play sfx
        if (buttonClickedEvent != null)
        {
            buttonClickedEvent();
        }

        midi.ReplaySong();
        SceneManager.LoadScene("Play");
    }

    void UpdateUserScore()
    {
        videoPlayer.Play();
        topBar.SetActive(false);
        updatePercentage();
        UpdateStars();
        UpdateHighScore();
        UpdateNotesHit();
        UpdatePlays();

        startLevel = PersistentData.data.level;

        LevelUp();
        UpdateUserMoney();
        UpdateUserMoneyUI();
        UpdateExpBar();


        // Save data computer
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

    public void UpdateExpBar()
    {
       

        levelTextStart.text = PersistentData.data.songStartPlayerExp.ToString();
        levelTextNext.text = "Next: " + ReturnXPNeededToLevelUp(PersistentData.data.level);

        // Calculate start exp
        startExp = PersistentData.data.songStartPlayerExp;
        endExp = PersistentData.data.exp;
        finalExp = ReturnXPNeededToLevelUp(PersistentData.data.level);
        endLevel = PersistentData.data.level;

        levelTextBig.text = "Level: " + startLevel;

        StartCoroutine(ExpSlider());
        
    }

    public IEnumerator ExpSlider()
    {
        
        // Handles slider exp for leveling animation
        if (startLevel != endLevel)
        {
            while (startExp/finalExp < 1)
            {
                PersistentData.data.isLevellingUp = true;
                if (LevellingUpEvent != null)
                {
                    LevellingUpEvent();
                }
                levelSlider.value = startExp / finalExp;
                startExp += 1f;
                levelTextStart.text = startExp.ToString();
                yield return new WaitForSeconds(0.01f);
            }
            PersistentData.data.isLevellingUp = false;
            startLevel += 1;
            startExp = 0;
            levelTextBig.text = "Level: " + startLevel;
            if (LevelUpEvent != null)
            {
                LevelUpEvent();
            }
        }


        // Handles slider exp for non-leveling animation
        while (startExp < endExp)
        {
            PersistentData.data.isLevellingUp = true;
            if (LevellingUpEvent != null)
            {
                LevellingUpEvent();
            }
            Debug.Log("Slider Start Animation: " + startExp);
            Debug.Log("Slider End Animation: " + endExp);
            levelSlider.value = startExp / finalExp;
            startExp += 1f;
            levelTextStart.text = startExp.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        PersistentData.data.isLevellingUp = false;

        Debug.Log("END");
        Debug.Log("Slider Start Animation: " + startExp);
        Debug.Log("Slider End Animation: " + endExp);



    }


    public void UpdateUserMoneyUI()
    {
        moneyNotesText.text = PersistentData.data.money.ToString();
    }

    void UpdateStars()
    {
        if ((percentTrunk * 100) < 20)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "*";
            OneStar();
        }else if ((percentTrunk * 100) > 20 && (percentTrunk * 100) < 40)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* *";
            TwoStar();
        }else if ((percentTrunk * 100) > 40 && (percentTrunk * 100) < 60)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * *";
            ThreeStar();
        }else if ((percentTrunk * 100) > 60 && (percentTrunk * 100) < 80)
        {
            PersistentData.data._SongList[PersistentData.data.selectedSong - 1]._stars = "* * * *";
            FourStar();
        }else if ((percentTrunk * 100) > 80)
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
        star1.gameObject.transform.localScale = new Vector3(0,0,0);
        LeanTween.scale(star1.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEaseOutSine();
        star2.gameObject.transform.localScale = new Vector3(0, 0, 0);
        star3.gameObject.transform.localScale = new Vector3(0, 0, 0);
        star4.gameObject.transform.localScale = new Vector3(0, 0, 0);
        star5.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void TwoStar()
    {
        star1.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star1.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEaseOutSine();
        star2.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star2.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.0f).setEaseOutSine();
        star3.gameObject.transform.localScale = new Vector3(0, 0, 0);
        star4.gameObject.transform.localScale = new Vector3(0, 0, 0);
        star5.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ThreeStar()
    {
        star1.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star1.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEaseOutSine();
        star2.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star2.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.0f).setEaseOutSine();
        star3.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star3.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.5f).setEaseOutSine();
        star4.gameObject.transform.localScale = new Vector3(0, 0, 0);
        star5.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void FourStar()
    {
        star1.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star1.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEaseOutSine();
        star2.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star2.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.0f).setEaseOutSine();
        star3.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star3.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.5f).setEaseOutSine();
        star4.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star4.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(2.0f).setEaseOutSine();
        star5.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    public void FiveStar()
    {
        star1.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star1.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEaseOutSine();
        star2.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star2.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.0f).setEaseOutSine();
        star3.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star3.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1.5f).setEaseOutSine();
        star4.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star4.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(2.0f).setEaseOutSine();
        star5.gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(star5.gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(2.5f).setEaseOutSine();
    }

}
