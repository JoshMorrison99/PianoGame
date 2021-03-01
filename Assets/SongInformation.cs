using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongInformation : MonoBehaviour
{

    public int selectedSong;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
