using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor;
using Melanchall.DryWetMidi.Devices;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

public class SongSelection : MonoBehaviour
{

    public delegate void ButtonClickAction();
    public static event ButtonClickAction buttonClickAction;

    // Song Filter
    public bool isFilterON;
    public GameObject SongFilterPanel;
    public Button UserSongFilterButton;
    public Image UserSongFilterImage;
    public Button BeginnerSongFilterButton;
    public Image BeginnerSongFilterImage;
    public Button MediumSongFilterButton;
    public Image MediumSongFilterImage;
    public Button HardSongFilterButton;
    public Image HardSongFilterImage;
    public Button NoneSongFilterButton;
    public Image NoneSongFilterImage;
    public string currentFilter;
    public GameObject bgDark;

    public Button FilterButton;
    public Button currentAppliedFilterButton;


    // Delete Song Panel
    public GameObject deleteSongPanel;
    public Button deleteSongYESButton;
    public Button deleteSongNOButton;
    public GameObject doDelete;

    //public PersistentData songInfo;
    private int index;

    public TextMeshProUGUI Ode_To_Joy_Percentage;
    //public TextMeshProUGUI See_you_Again_Percentage;

    // Generated Information
    public TextMeshProUGUI SongTitle;
    public TextMeshProUGUI SongAuthor;
    public TextMeshProUGUI HighScore_Text;
    public TextMeshProUGUI Plays_Text;
    public TextMeshProUGUI Stars_Text;
    public TextMeshProUGUI NotesHit_Text;
    public TextMeshProUGUI Difficulty_Text;

    public TextMeshProUGUI playerLevelUI;
    public TextMeshProUGUI playerMoneyUI;

    public List<Button> myButtonSongs;

    public GameObject songObjectTemplate;


    private void Start()
    {
        //PersistentData.data.ReInitializeData();
        //Debug.Log("===========================================================" + PersistentData.data._SongList.Count);
        //PersistentData.LoadJsonData(PersistentData.data);

        createSongsFromTemplate("all");

        GameObject buttonHolder = GameObject.Find("Content");
        setDefaultSongSelection();
        //Button firstBtn = buttonHolder.transform.GetChild(0).GetComponent<Button>();
        //firstBtn.onClick.Invoke();

        // Player persistent data UI
        playerLevelUI.text = PersistentData.data.level.ToString();
        playerMoneyUI.text = PersistentData.data.money.ToString();

        
        updatePercentageUI();

        deleteSongPanel.SetActive(false);
        isFilterON = false;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
        SongFilterPanel.SetActive(false);
        currentFilter = "all";
        NoneSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
    }


    public void createSongsFromTemplate(string filter)
    {

        GameObject SongHolder = GameObject.Find("Content");

        // Remove all children
        foreach (Transform child in SongHolder.transform)
        {
            Destroy(child.gameObject);
        }

        if(filter == "all")
        {
            foreach (SongInfo each in PersistentData.data._SongList)
            {
                //Debug.Log(each._SongTitle);
                GameObject newSong = Instantiate(songObjectTemplate);
                newSong.GetComponent<SongInfo>()._SongTitle = each._SongTitle;
                newSong.GetComponent<SongInfo>()._SongAuthor = each._SongAuthor;
                newSong.GetComponent<SongInfo>()._plays = each._plays;
                newSong.GetComponent<SongInfo>()._notesHit = each._notesHit;
                newSong.GetComponent<SongInfo>()._highScore = each._highScore;
                newSong.GetComponent<SongInfo>()._Difficulty = each._Difficulty;
                newSong.GetComponent<SongInfo>()._stars = each._stars;
                newSong.GetComponent<SongInfo>()._songCompletionPercentage = each._songCompletionPercentage;
                newSong.GetComponent<SongInfo>()._songID = PersistentData.data.songImportIndex;

                //PersistentData.data.songImportIndex += 1;

                newSong.transform.SetParent(SongHolder.transform);
                newSong.transform.localScale = new Vector3(1, 1, 1);

                newSong.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = each._SongTitle;
                newSong.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = each._SongAuthor;

                // Update the percentage text
                newSong.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = each._songCompletionPercentage.ToString() + "%";

                // Render the remove button or not
                if (newSong.GetComponent<SongInfo>()._SongAuthor != "user")
                {
                    newSong.transform.GetChild(5).gameObject.SetActive(false);
                }

                

            }
        }else
        {
            foreach (SongInfo each in PersistentData.data._SongList)
            {
                
                Debug.Log(each._SongTitle);
                GameObject newSong = Instantiate(songObjectTemplate);
                newSong.GetComponent<SongInfo>()._SongTitle = each._SongTitle;
                newSong.GetComponent<SongInfo>()._SongAuthor = each._SongAuthor;
                newSong.GetComponent<SongInfo>()._plays = each._plays;
                newSong.GetComponent<SongInfo>()._notesHit = each._notesHit;
                newSong.GetComponent<SongInfo>()._highScore = each._highScore;
                newSong.GetComponent<SongInfo>()._Difficulty = each._Difficulty;
                newSong.GetComponent<SongInfo>()._stars = each._stars;
                newSong.GetComponent<SongInfo>()._songCompletionPercentage = each._songCompletionPercentage;
                newSong.GetComponent<SongInfo>()._songID = PersistentData.data.songImportIndex;

                //PersistentData.data.songImportIndex += 1;

                newSong.transform.SetParent(SongHolder.transform);
                newSong.transform.localScale = new Vector3(1, 1, 1);

                newSong.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = each._SongTitle;
                newSong.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = each._SongAuthor;

                // Update the percentage text
                newSong.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = each._songCompletionPercentage.ToString() + "%";

                // Render the remove button or not
                if (newSong.GetComponent<SongInfo>()._SongAuthor != "user")
                {
                    newSong.transform.GetChild(5).gameObject.SetActive(false);
                }

                if (each._Difficulty.ToLower() != filter.ToLower())
                {
                    newSong.gameObject.SetActive(false);
                }

                

            }
        }

        
    }

    public void deleteButtonClicked(Button button)
    {
        deleteSongPanel.SetActive(true);
        doDelete = button.GetComponentInParent<SongInfo>().gameObject;

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }
    

    public void updatePercentageUI()
    {
        Debug.Log("==============================START================================");
        GameObject content = GameObject.Find("Content");
        int loopIndex = 0;
        foreach (Transform child in content.transform)
        {
            //Debug.Log(child.gameObject);
            Transform percentageText = child.gameObject.transform.Find("Percentage");
            //Debug.Log("PersistentData.data._SongList[loopIndex]._songCompletionPercentage.ToString() " + PersistentData.data._SongList[loopIndex]._songCompletionPercentage);
            //Debug.Log(loopIndex);
            //Debug.Log(PersistentData.data._SongList);
            percentageText.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = PersistentData.data._SongList[loopIndex]._songCompletionPercentage.ToString() + "%";
            loopIndex += 1;
        }
        //Debug.Log("==============================END================================");
    }




    public void onClickSongSelection(Button button)
    {
        index = button.transform.GetSiblingIndex();
        SongInfo songClicked = PersistentData.data._SongList[index];
        SongTitle.text = songClicked._SongTitle;
        SongAuthor.text = songClicked._SongAuthor;
        HighScore_Text.text = songClicked._highScore.ToString();
        Plays_Text.text = songClicked._plays.ToString();
        Stars_Text.text = songClicked._stars.ToString();
        NotesHit_Text.text = songClicked._notesHit.ToString() + " / " + songClicked._totalNote.ToString();
        Difficulty_Text.text = songClicked._Difficulty;

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void setDefaultSongSelection()
    {
        SongInfo songClicked = PersistentData.data._SongList[0];
        SongTitle.text = songClicked._SongTitle;
        SongAuthor.text = songClicked._SongAuthor;
        HighScore_Text.text = songClicked._highScore.ToString();
        Plays_Text.text = songClicked._plays.ToString();
        Stars_Text.text = songClicked._stars.ToString();
        NotesHit_Text.text = songClicked._notesHit.ToString() + " / " + songClicked._totalNote.ToString();
        Difficulty_Text.text = songClicked._Difficulty;
    }

    public void onClickPlay()
    {
        PersistentData.data.selectedSong = index + 1;
        PersistentData.data.userSongSelected = PersistentData.data._SongList[index]._FileName;
        PersistentData.data.songStartPlayerExp = PersistentData.data.exp;
        SceneManager.LoadScene("Play");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void ImportUserSong(string songName)
    {

        GameObject songObjectTemplateUser = Instantiate(songObjectTemplate);

        songObjectTemplateUser.GetComponent<SongInfo>()._songID = PersistentData.data.songImportIndex;
        songObjectTemplateUser.GetComponent<SongInfo>()._SongTitle = songName;
        songObjectTemplateUser.GetComponent<SongInfo>()._SongAuthor = "user";
        songObjectTemplateUser.GetComponent<SongInfo>()._Difficulty = "user";
        songObjectTemplateUser.GetComponent<SongInfo>()._stars = "";
        MidiFile midiFile = MidiFile.Read("./Assets/MidiFiles/UserMidiFiles/" + songName);
        songObjectTemplateUser.GetComponent<SongInfo>()._totalNote = midiFile.GetNotes().Count;
        songObjectTemplateUser.GetComponent<SongInfo>()._songCompletionPercentage = 0;
        songObjectTemplateUser.GetComponent<SongInfo>()._plays = 0;
        songObjectTemplateUser.GetComponent<SongInfo>()._FileName = songName;
        songObjectTemplateUser.GetComponent<SongInfo>()._highScore = 0;
        songObjectTemplateUser.GetComponent<SongInfo>()._notesHit = 0;


        PersistentData.data.songImportIndex += 1;

        songObjectTemplateUser.transform.localScale = new Vector3(1,1,1);
        songObjectTemplateUser.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = songName;
        songObjectTemplateUser.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "user";

        GameObject songCollection = GameObject.Find("Songs");
        songObjectTemplateUser.transform.SetParent(songCollection.transform);

        PersistentData.data._SongList.Add(songObjectTemplateUser.GetComponent<SongInfo>());

        // Save data
        PersistentData.SaveJsonData(PersistentData.data);

        createSongsFromTemplate(currentFilter);

    }

    public void DeleteSongYESPressed()
    {
        
        index = doDelete.transform.GetSiblingIndex();

        Debug.Log("index: " + index);
        PersistentData.data.songImportIndex -= 1;

        string ResourcesPath = "Assets/MidiFiles/UserMidiFiles";
        string songName = PersistentData.data._SongList[index]._SongTitle;
        FileUtil.DeleteFileOrDirectory(ResourcesPath + "/" + songName);

        Debug.Log("DELETING: " + songName);

        PersistentData.data._SongList.RemoveAt(index);
        PersistentData.SaveJsonData(PersistentData.data);

        createSongsFromTemplate(currentFilter);

        deleteSongPanel.SetActive(false);

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void DeleteSongNOPressed()
    {
        deleteSongPanel.SetActive(false);

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void FilterButtonClicked()
    {
        if (isFilterON)
        {
            SongFilterPanel.SetActive(false);
            bgDark.SetActive(false);
            isFilterON = false;
        }
        else
        {
            SongFilterPanel.SetActive(true);
            bgDark.SetActive(true);
            isFilterON = true;
        }

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void NoneSongFilterButtonClicked()
    {
        NoneSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
        UserSongFilterImage.color = Color.white;
        BeginnerSongFilterImage.color = Color.white;
        MediumSongFilterImage.color = Color.white;
        HardSongFilterImage.color = Color.white;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
        SongFilterPanel.SetActive(false);
        isFilterON = false;
        currentFilter = "all";
        createSongsFromTemplate("all");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void UserSongFilterButtonClicked()
    {
        NoneSongFilterImage.color = Color.white;
        UserSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
        BeginnerSongFilterImage.color = Color.white;
        MediumSongFilterImage.color = Color.white;
        HardSongFilterImage.color = Color.white;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "[ User Songs ]";
        SongFilterPanel.SetActive(false);
        isFilterON = false;
        currentFilter = "user";
        createSongsFromTemplate("user");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void BeginnerSongFilterButtonClicked()
    {
        NoneSongFilterImage.color = Color.white;
        UserSongFilterImage.color = Color.white;
        BeginnerSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
        MediumSongFilterImage.color = Color.white;
        HardSongFilterImage.color = Color.white;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "[ Beginner Difficulty ]";
        SongFilterPanel.SetActive(false);
        isFilterON = false;
        currentFilter = "beginner";
        createSongsFromTemplate("beginner");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void MediumSongFilterButtonClicked()
    {
        NoneSongFilterImage.color = Color.white;
        UserSongFilterImage.color = Color.white;
        BeginnerSongFilterImage.color = Color.white;
        MediumSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
        HardSongFilterImage.color = Color.white;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "[ Medium Difficulty ]";
        SongFilterPanel.SetActive(false);
        isFilterON = false;
        currentFilter = "medium";
        createSongsFromTemplate("medium");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void HardSongFilterButtonClicked()
    {
        NoneSongFilterImage.color = Color.white;
        UserSongFilterImage.color = Color.white;
        BeginnerSongFilterImage.color = Color.white;
        MediumSongFilterImage.color = Color.white;
        HardSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "[ Hard Difficulty ]";
        SongFilterPanel.SetActive(false);
        isFilterON = false;
        currentFilter = "hard";
        createSongsFromTemplate("hard");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

    public void ClearFilterButtonClicked()
    {
        NoneSongFilterImage.color = COLOR_PALLETE.LIGHT_BLUE;
        UserSongFilterImage.color = Color.white;
        BeginnerSongFilterImage.color = Color.white;
        MediumSongFilterImage.color = Color.white;
        HardSongFilterImage.color = Color.white;
        currentAppliedFilterButton.GetComponentInChildren<TextMeshProUGUI>().text = "";
        SongFilterPanel.SetActive(false);
        isFilterON = false;
        currentFilter = "all";
        createSongsFromTemplate("all");

        // Play button click sfx
        if (buttonClickAction != null)
        {
            buttonClickAction();
        }
    }

}
