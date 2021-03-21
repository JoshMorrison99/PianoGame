using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class detectorScript : MonoBehaviour
{
    public bool overlapScore = false;
    public bool overlapNote = false;
    public int initalId;

    public PlayLogic Logic;

    public PianoKeyPresses PianoKeysObject;
    public List<GameObject> currentOverlappedNotes;

    public bool isPressed;


    void Start()
    {
        
        PianoKeysObject = GameObject.Find("PianoKeyboardUI").GetComponent<PianoKeyPresses>();

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;



            midiDevice.onWillNoteOn += (note, velocity) => {
                PianoKeyPressedUI(note.shortDisplayName);
            };

            midiDevice.onWillNoteOff += (note) => {
                PianoKeyLiftedUI(note.shortDisplayName);
            };
        };
    }

    void PianoKeyPressedUI(string notePressed)
    {
        foreach (GameObject each in PianoKeysObject.PianoKeys)
        {
            if (each.name == notePressed)
            {

                foreach (GameObject each2 in currentOverlappedNotes)
                {
                    if (each.GetComponent<Note_Mine>().noteName == each2.GetComponent<Note_Falling>().noteName && each2.GetComponent<Note_Falling>().isHit == false)
                    {
                        each2.GetComponent<Note_Falling>().isHit = true;
                        IncrementNotesHit();
                    }else if (each.GetComponent<Note_Mine>().noteName == each2.GetComponent<Note_Falling>().noteName)
                    {
                        each.GetComponent<Note_Mine>().initialPress = true;
                        isPressed = each.GetComponent<Note_Mine>().initialPress = true;
                        StartCoroutine(ScoreIncrementer());
                    }
                }

            }
        }
    }

    private IEnumerator ScoreIncrementer()
    {
        
        while (isPressed)
        {

            Logic.currentScore += 1;

            yield return null;

        }

        yield return null;


    }

    void PianoKeyLiftedUI(string notePressed)
    {
        foreach (GameObject each in PianoKeysObject.PianoKeys)
        {
            if (each.name == notePressed)
            {

                each.GetComponent<Note_Mine>().initialPress = false;
                isPressed = each.GetComponent<Note_Mine>().initialPress = false;
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.gameObject.tag == "Note")
        {
            overlapNote = true;
            currentOverlappedNotes.Add(collision.GetComponentInParent<Note_Falling>().gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            overlapNote = false;
            isPressed = false;
            currentOverlappedNotes.Remove(collision.GetComponentInParent<Note_Falling>().gameObject);
        }
    }

    
    void IncrementNotesHit()
    {

        // Note successfully hit
        Logic.numNotesHit += 1;

        // Increment exp
        PersistentData.data.exp += 1;

    }
}
