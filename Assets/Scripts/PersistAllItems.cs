using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAllItems : MonoBehaviour
{
    public PersistAllItems data;

    private void Awake()
    {
        if (data != null)
        {
            Debug.LogError("An instance already exists");
            Destroy(this);
            return;
        }
        data = this;
    }
}
