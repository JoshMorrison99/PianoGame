using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistSongsAll : MonoBehaviour
{

    public static PersistSongsAll data;
    private void Awake()
    {
        

        /*if (data != null && data != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            data = this;
            DontDestroyOnLoad(gameObject);
        }*/

        if (data == null)
        {
            Debug.Log("DATA IS NULL");
            DontDestroyOnLoad(this);
            data = this;

            

        }
        else
        {
            Debug.Log("DATA IS NOT NULL");
            Destroy(this.gameObject);
        }
    }
}
