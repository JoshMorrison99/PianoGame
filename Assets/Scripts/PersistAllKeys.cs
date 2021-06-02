using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAllKeys : MonoBehaviour
{
    public static PersistAllKeys data;
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
