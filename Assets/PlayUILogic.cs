using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUILogic : MonoBehaviour
{

    public PlayLogic playSongLogic;

    public TextMeshProUGUI progressSong;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progressSong.text = playSongLogic.numNotesHit + "/" + playSongLogic.numNotesTotal;
    }
}
