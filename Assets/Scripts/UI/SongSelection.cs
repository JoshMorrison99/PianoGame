using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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
        PersistentData.data.ReInitializeData();

        GameObject buttonHolder = GameObject.Find("Content");
        Button firstBtn = buttonHolder.transform.GetChild(0).GetComponent<Button>();
        firstBtn.onClick.Invoke();

        // Player persistent data UI
        playerLevelUI.text = PersistentData.data.level.ToString();
        playerMoneyUI.text = PersistentData.data.money.ToString();

        
        updatePercentageUI();
        

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
        GameObject userSongCollection = GameObject.Find("Content");

        GameObject songObjectTemplateUser = Instantiate(songObjectTemplate);

        PersistentData.data.songImportIndex = 0; // USE THIS HERE WHILE DEBUGGING

        songObjectTemplateUser.GetComponent<SongInfo>()._songID = 5 + PersistentData.data.songImportIndex;
        songObjectTemplateUser.GetComponent<SongInfo>()._SongTitle = songName;
        songObjectTemplateUser.GetComponent<SongInfo>()._SongAuthor = "user";

        PersistentData.data.songImportIndex += 1;

        // Save data
        PersistentData.SaveJsonData(PersistentData.data);

        songObjectTemplateUser.transform.parent = userSongCollection.transform;
        songObjectTemplateUser.transform.localScale = new Vector3(1,1,1);
        songObjectTemplateUser.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = songName;
        songObjectTemplateUser.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "user";

        PersistentData.data._SongList.Add(songObjectTemplateUser.GetComponent<SongInfo>());



        
    }

}
