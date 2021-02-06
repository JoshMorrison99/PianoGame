using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoNoteSpawner : MonoBehaviour
{

    public GameObject spawnNoteObject;
    public GameObject spawnNoteSharpObject;

    public PianoUI pianoListRef;

    public List<GameObject> spawnedNotes;
    float noteSpeed = 0.005f;

    // Piano Notes
    GameObject C2;
    GameObject D2;
    GameObject E2;
    GameObject F2;
    GameObject G2;
    GameObject A2;
    GameObject B2;
    GameObject Cs2;
    GameObject Ds2;
    GameObject Fs2;
    GameObject Gs2;
    GameObject As2;

    private void Start()
    {
        setupUI();
        spawnNote(1, C2, 0, false);
        spawnNote(1, F2, 1, false);
        spawnNote(1, B2, 2, false);
        spawnNote(1, Fs2, 3, true);
        spawnNote(1, E2, 4, false);
        spawnNote(1, G2, 5, false);
        spawnNote(1, Gs2, 6, true);
    }

    private void Update()
    {
        foreach (GameObject each in spawnedNotes){
            if (each.transform.position.y > -5)
            {
                each.transform.position = new Vector3(each.transform.position.x, each.transform.position.y - noteSpeed, each.transform.position.z);
            }
            else
            {
                spawnedNotes.Remove(each);
                Destroy(each);
            }
        }
        
    }

    public void spawnNote(float noteDuration, GameObject note, int id, bool isSharp)
    {
        if (isSharp)
        {
            spawnedNotes.Add(Instantiate(spawnNoteSharpObject, new Vector3(note.transform.position.x, note.transform.position.y + 8.55f, note.transform.position.z), Quaternion.identity));
        }
        else
        {
            spawnedNotes.Add(Instantiate(spawnNoteObject, new Vector3(note.transform.position.x, note.transform.position.y + 9, note.transform.position.z), Quaternion.identity));
        }
    }

    public void setupUI()
    {
        // Octave 1
        C2 = pianoListRef.PianoKeys[0];
        D2 = pianoListRef.PianoKeys[1];
        E2 = pianoListRef.PianoKeys[2];
        F2 = pianoListRef.PianoKeys[3];
        G2 = pianoListRef.PianoKeys[4];
        A2 = pianoListRef.PianoKeys[5];
        B2 = pianoListRef.PianoKeys[6];
        Cs2 = pianoListRef.PianoKeys[7];
        Ds2 = pianoListRef.PianoKeys[8];
        Fs2 = pianoListRef.PianoKeys[9];
        Gs2 = pianoListRef.PianoKeys[10];
        As2 = pianoListRef.PianoKeys[11];
    }
}
