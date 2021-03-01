using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song1 : MonoBehaviour
{
    PianoNoteSpawner spawner;

    private float TicksPerSecond = 1.5f;

    private float _t;
    private int counter = 0;

    void OnEnable()
    {
        _t = 0f;
    }

    private void Start()
    {
        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();
        Debug.Log(spawner);
    }

    // Update is called once per frame
    void Update()
    {
        // Begin Song
        float dur = 1f / this.TicksPerSecond;
        _t += Time.deltaTime;
        int cnt = 4;
        while (_t > dur && cnt > 0)
        {
            counter++;
            _t -= dur;
            cnt--;
            beginSong();
        }
    }

    void beginSong()
    {
        spawner.spawnNote(0, spawner.G6, false);
    }
}
