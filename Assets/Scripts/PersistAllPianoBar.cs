using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAllPianoBar : MonoBehaviour
{
    public static PersistAllPianoBar data;
    private void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
