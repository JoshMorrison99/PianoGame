using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SongSelection : MonoBehaviour
{

    public PersistentData songInfo;
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


    private void Start()
    {
        Ode_To_Joy_Percentage.text = PersistentData.data.song_Ode_To_Joy_Completion.ToString() + "%";
        //See_you_Again_Percentage.text = PersistentData.data.song_See_you_Again_Completion.ToString() + "%";

    }

    // Update is called once per frame
    void Update()
    {

    }


/*    public void SelectSong1()
    {
        Debug.Log("Pressed");
        songInfo.GetComponent<PersistentData>().selectedSong = 1;
        SceneManager.LoadScene("Play");
    }
    public void SelectSong2()
    {
        Debug.Log("Pressed");
        songInfo.GetComponent<PersistentData>().selectedSong = 2;
        SceneManager.LoadScene("Play");
    }
    public void SelectSong3()
    {
        Debug.Log("Pressed");
        songInfo.selectedSong = 3;
        SceneManager.LoadScene("Play");
    }
    public void SelectSong4()
    {
        Debug.Log("Pressed");
        songInfo.selectedSong = 4;
        SceneManager.LoadScene("Play");
    }

    public void SelectSong5()
    {
        Debug.Log("Pressed");
        songInfo.selectedSong = 5;
        SceneManager.LoadScene("Play");
    }

    public void SelectSong6()
    {
        Debug.Log("Pressed");
        songInfo.selectedSong = 6;
        SceneManager.LoadScene("Play");
    }*/

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
        songInfo.selectedSong = index + 1;
        SceneManager.LoadScene("Play");
    }

}