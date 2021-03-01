using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongSelection : MonoBehaviour
{

    SongInformation songInfo;
    public Button Song1Btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSong1()
    {
        Debug.Log("Pressed");
        SceneManager.LoadScene("Play");
    } 
    
     public void Debugger()
    {
        Debug.Log("Pressed");
    }
}
