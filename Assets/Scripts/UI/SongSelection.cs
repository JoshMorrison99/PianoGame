using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor;

public class SongSelection : MonoBehaviour
{

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
        Debug.Log("===========================================================" + PersistentData.data._SongList.Count);
        //PersistentData.LoadJsonData(PersistentData.data);

        createSongsFromTemplate();

        GameObject buttonHolder = GameObject.Find("Content");
        Button firstBtn = buttonHolder.transform.GetChild(0).GetComponent<Button>();
        firstBtn.onClick.Invoke();

        // Player persistent data UI
        playerLevelUI.text = PersistentData.data.level.ToString();
        playerMoneyUI.text = PersistentData.data.money.ToString();

        
        updatePercentageUI();
        

    }


    public void createSongsFromTemplate()
    {

        GameObject SongHolder = GameObject.Find("Content");

        // Remove all children
        foreach (Transform child in SongHolder.transform)
        {
            Destroy(child.gameObject);
        }



        foreach (SongInfo each in PersistentData.data._SongList)
        {
            GameObject newSong = Instantiate(songObjectTemplate);
            newSong.GetComponent<SongInfo>()._SongTitle = each._SongTitle;
            newSong.GetComponent<SongInfo>()._SongAuthor = each._SongAuthor;
            newSong.GetComponent<SongInfo>()._plays = each._plays;
            newSong.GetComponent<SongInfo>()._notesHit = each._notesHit;
            newSong.GetComponent<SongInfo>()._highScore = each._highScore;
            newSong.GetComponent<SongInfo>()._Difficulty = each._Difficulty;
            newSong.GetComponent<SongInfo>()._stars = each._stars;
            newSong.GetComponent<SongInfo>()._songID = PersistentData.data.songImportIndex;

            PersistentData.data.songImportIndex += 1;

            newSong.transform.SetParent(SongHolder.transform);
            newSong.transform.localScale = new Vector3(1,1,1);

            newSong.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = each._SongTitle;
            newSong.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = each._SongAuthor;

            // Render the remove button or not
            if (newSong.GetComponent<SongInfo>()._SongAuthor != "user")
            {
                newSong.transform.GetChild(5).gameObject.SetActive(false);
            }
        }
    }

    public void deleteButtonClicked(Button button)
    {
        index = button.transform.GetSiblingIndex();
        

        PersistentData.data.songImportIndex -= 1;

        string ResourcesPath = "Assets/MidiFiles/UserMidiFiles";
        string songName = PersistentData.data._SongList[index - 1]._SongTitle;
        FileUtil.DeleteFileOrDirectory(ResourcesPath + "/" + songName);

        PersistentData.data._SongList.RemoveAt(index - 1);
        PersistentData.SaveJsonData(PersistentData.data);

        createSongsFromTemplate();
    }
    

    public void updatePercentageUI()
    {
        ContentSizeFitter content = this.GetComponentInChildren<ContentSizeFitter>();
        int loopIndex = 0;
        foreach (Transform child in content.transform)
        {
            //Debug.Log(child.gameObject);
            Transform percentageText = child.gameObject.transform.Find("Percentage");
            //Debug.Log(PersistentData.data._SongList[loopIndex]._songCompletionPercentage);
            //Debug.Log(loopIndex);
            //Debug.Log(PersistentData.data._SongList);
            percentageText.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = PersistentData.data._SongList[loopIndex]._songCompletionPercentage.ToString() + "%";
            loopIndex += 1;
        }
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
    }

    public void onClickPlay()
    {
        PersistentData.data.selectedSong = index + 1;
        PersistentData.data.userSongSelected = PersistentData.data._SongList[index]._SongTitle;
        SceneManager.LoadScene("Play");
    }

    public void ImportUserSong(string songName)
    {

        GameObject songObjectTemplateUser = Instantiate(songObjectTemplate);

        songObjectTemplateUser.GetComponent<SongInfo>()._songID = PersistentData.data.songImportIndex;
        songObjectTemplateUser.GetComponent<SongInfo>()._SongTitle = songName;
        songObjectTemplateUser.GetComponent<SongInfo>()._SongAuthor = "user";

        PersistentData.data.songImportIndex += 1;

        songObjectTemplateUser.transform.localScale = new Vector3(1,1,1);
        songObjectTemplateUser.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = songName;
        songObjectTemplateUser.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "user";

        GameObject songCollection = GameObject.Find("Songs");
        songObjectTemplateUser.transform.SetParent(songCollection.transform);

        PersistentData.data._SongList.Add(songObjectTemplateUser.GetComponent<SongInfo>());


        // Save data
        PersistentData.SaveJsonData(PersistentData.data);


        createSongsFromTemplate();

    }

}
