using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SongSelection : MonoBehaviour
{

    public PersistentData songInfo;

    public TextMeshProUGUI Ode_To_Joy_Percentage;

    private void Start()
    {
        Ode_To_Joy_Percentage.text = PersistentData.data.song_Ode_To_Joy_Completion.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SelectSong1()
    {
        Debug.Log("Pressed");
        songInfo.GetComponent<PersistentData>().selectedSong = 1;
        SceneManager.LoadScene("Play");
    }
    public void SelectSong2()
    {
        Debug.Log("Pressed");
        songInfo.selectedSong = 2;
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
    }

}
