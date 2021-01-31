using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PianoUI : MonoBehaviour
{
    public Image[] PianoKeys;
    public List<Image> currentPressedNotes;

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
        foreach (Image each in PianoKeys)
        {
            if (each.name == notePressed)
            {
                currentPressedNotes.Add(each);
                each.color = Color.red;
            }
        }
    }

    void PianoKeyLiftedUI(string notePressed)
    {
        foreach (Image each in PianoKeys)
        {
            if (each.name == notePressed)
            {
                currentPressedNotes.Remove(each);
                each.color = Color.white;
            }
        }
    }


}
