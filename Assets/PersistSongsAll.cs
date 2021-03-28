using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistSongsAll : MonoBehaviour
{

    public PersistSongsAll data;

    private void Awake()
    {
        if (data != null && data != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            data = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
