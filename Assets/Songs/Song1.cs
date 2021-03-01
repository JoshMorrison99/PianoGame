using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song1 : MonoBehaviour
{
    PianoNoteSpawner spawner;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawner.spawnNote(0, spawner.G6, false);
    }
}
