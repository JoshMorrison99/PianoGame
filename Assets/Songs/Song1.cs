using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song1 : MonoBehaviour
{
    PianoNoteSpawner spawner;
    public int numNotes = 63;

    public PlayUILogic UILogic;

    private void Start()
    {
        numNotes = 63;

        spawner = GameObject.Find("PianoKeyboardUI").GetComponent<PianoNoteSpawner>();

        UILogic = GameObject.Find("Canvas").GetComponent<PlayUILogic>();

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

        yield return new WaitForSeconds(5f);
        EndOfSong();
    }

    void EndOfSong()
    {
        UILogic.pauseMenuPanel.SetActive(true);
        UILogic.UpdateFinishedSongText();
    }
}
