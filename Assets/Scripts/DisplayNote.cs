using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using System;
using TMPro;

public class DisplayNote : MonoBehaviour
{
    Minis.MidiDevice midiDevice;
    public TMP_Text displayNoteText;

    // Start is called before the first frame update
    void Start()
    {

        foreach (var each in InputSystem.devices)
        {
            if (each.displayName != "Mouse")
            {
                midiDevice = each as Minis.MidiDevice;
                Debug.Log("FOUND:" + midiDevice);

                midiDevice.onWillNoteOn += (note, velocity) => {
                    displayNoteText.text = note.shortDisplayName;
                };

                midiDevice.onWillNoteOff += (note) => {
                    
                };
            }

        }

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) => {
                displayNoteText.text = note.shortDisplayName;
            };

            midiDevice.onWillNoteOff += (note) => {
                //displayNoteText.text = " ";
            };
        };
    }
}
