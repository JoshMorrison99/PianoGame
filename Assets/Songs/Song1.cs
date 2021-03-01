using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song1 : MonoBehaviour
{
    PianoNoteSpawner spawner;
    public int numNotes = 63;

    private void Start()
    {
        numNotes = 63;

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();
        Debug.Log(spawner);

        StartCoroutine(BeginSong());
    }

    IEnumerator BeginSong()
    {
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.G3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.G3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.G3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.G3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.G2, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.G3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.G3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.F3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.E3, false);
        yield return new WaitForSeconds(0.5f);

        spawner.spawnNote(0, spawner.D3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
        spawner.spawnNote(0, spawner.C3, false);
        yield return new WaitForSeconds(0.5f);
    }
}
