using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class detectorScript : MonoBehaviour
{
    public bool overlapScore = false;
    public bool overlapNote = false;
    public int initalId;

    public Minis.MidiDevice midiDevice;

    public PlayLogic Logic;

    public PianoKeyPresses PianoKeysObject;
    public List<GameObject> currentOverlappedNotes;

    public bool isPressed;


    void Start()
    {
        
        PianoKeysObject = GameObject.Find("PianoKeyboardUI").GetComponent<PianoKeyPresses>();
        DeviceFinder.DeviceAddedEvent += AddDevices;


        if (DeviceFinder.device.midiDevice != null)
        {
            AddDevices();
        }

        
    }

    public void AddDevices()
    {
        DeviceFinder.device.midiDevice.onWillNoteOn += (note, velocity) => {
            if (SceneManager.GetActiveScene().name == "Play")
            {
                PianoKeyPressedUI(note.shortDisplayName);
            }
        };

        DeviceFinder.device.midiDevice.onWillNoteOff += (note) => {
            if (SceneManager.GetActiveScene().name == "Play")
            {
                PianoKeyLiftedUI(note.shortDisplayName);
            }
        };
    }

    void PianoKeyPressedUI(string notePressed)
    {

        foreach (GameObject each in PianoKeysObject.PianoKeys)
        {
            if (each == null) return ;
            if (each.name == notePressed)
            {

                foreach (GameObject each2 in currentOverlappedNotes)
                {
                    if (each.GetComponent<Note_Mine>().noteName == each2.GetComponent<Note_Falling>().noteName && each2.GetComponent<Note_Falling>().isHit == false)
                    {
                        each2.GetComponent<Note_Falling>().isHit = true;
                        IncrementNotesHit();
                        noteHitVFX(each);
                    }
                    else if (each.GetComponent<Note_Mine>().noteName == each2.GetComponent<Note_Falling>().noteName)
                    {
                        each.GetComponent<Note_Mine>().initialPress = true;
                        isPressed = each.GetComponent<Note_Mine>().initialPress = true;
                        StartCoroutine(ScoreIncrementer());
                    }
                }

            }
        }
    }


    public void noteHitVFX(GameObject key)
    {
        //key.GetComponentInChildren<ParticleSystem>().Play();             IF YOU WERE TO SOMEHOW FIND A WAY TO MAKE THE PARTICLE SYSTEM NOT DISTRACTING TO THE USER, THIS IS WHERE YOU IMPLEMENT IT...
    }

    private IEnumerator ScoreIncrementer()
    {
        
        while (isPressed && PersistentData.data.isPaused == false)
        {

            Logic.currentScore += 1;

            yield return null;

        }

        yield return null;


    }

    void Video(string note, int color)
    {
        if (color == 1)
        {
            foreach(GameObject key in PianoKeysObject.PianoKeys)
            {
                if (key.GetComponent<Note_Mine>().noteName == note)
                {
                    key.GetComponent<SpriteRenderer>().color = new Color(PersistentData.data.currentKeyItem.r, PersistentData.data.currentKeyItem.g, PersistentData.data.currentKeyItem.b,255);
                }
            }
        }
        
        if(color == 0)
        {
            foreach (GameObject key in PianoKeysObject.PianoKeys)
            {
                if (key.GetComponent<Note_Mine>().noteName == note)
                {
                    if (key.GetComponent<Note_Mine>().noteName.Contains("#"))
                    {
                        key.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                    else
                    {
                        key.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
            }
        }
    }

    void PianoKeyLiftedUI(string notePressed)
    {
        foreach (GameObject each in PianoKeysObject.PianoKeys)
        {
            if (each == null) { return; }
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
            Video(collision.GetComponentInParent<Note_Falling>().noteName, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            overlapNote = false;
            isPressed = false;
            currentOverlappedNotes.Remove(collision.GetComponentInParent<Note_Falling>().gameObject);
            Video(collision.GetComponentInParent<Note_Falling>().noteName, 0);
        }
    }

    
    void IncrementNotesHit()
    {
        if (PersistentData.data.isPaused == false)
        {
            // Note successfully hit
            Logic.numNotesHit += 1;

            // Increment exp
            PersistentData.data.exp += 1;
        }

    }
}
