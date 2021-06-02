using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAllItems : MonoBehaviour
{
    public static PersistAllItems data;

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
