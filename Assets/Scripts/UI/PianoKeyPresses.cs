using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PianoKeyPresses : MonoBehaviour
{
    public GameObject[] PianoKeys;
    public List<GameObject> currentPressedNotes;


    void Start()
    {
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
        foreach (GameObject each in PianoKeys)
        {
            if (each.name == notePressed)
            {
                currentPressedNotes.Add(each);
                each.GetComponent<SpriteRenderer>().color = Color.red;

                // Activate the Note
                each.GetComponent<Note>().isPressed = true;
                each.GetComponent<Note>().initialPress = true;
            }
        }
    }

    void PianoKeyLiftedUI(string notePressed)
    {
        foreach (GameObject each in PianoKeys)
        {
            if (each.name == notePressed)
            {
                currentPressedNotes.Remove(each);
                if (notePressed.Contains("#"))
                {
                    each.GetComponent<SpriteRenderer>().color = Color.black;
                }
                else
                {
                    each.GetComponent<SpriteRenderer>().color = Color.white;
                }

                // Deactivate the Note
                each.GetComponent<Note>().isPressed = false;
            }
        }
    }


}
