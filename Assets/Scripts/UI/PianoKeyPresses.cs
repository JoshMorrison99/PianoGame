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

    Minis.MidiDevice midiDevice;
    /*void SetupKeyboardInput()
    {
        foreach (var each in InputSystem.devices)
        {
            if (each.displayName != "Mouse")
            {

            }

        }

        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    // New Device.
                    Debug.Log("Device Added: " + device);
                    InputSystem.AddDevice(device);
                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged.
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in.

                    break;
                case InputDeviceChange.Removed:
                    // Remove from Input System entirely; by default, Devices stay in the system once discovered.
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    break;
            }
        };
    }*/

    void Start()
    {

        

        foreach (var each in InputSystem.devices)
        {
            if (each.displayName != "Mouse")
            {
                midiDevice = each as Minis.MidiDevice;
                Debug.Log("FOUND:" + midiDevice);

                midiDevice.onWillNoteOn += (note, velocity) => {
                    PianoKeyPressedUI(note.shortDisplayName);
                };

                midiDevice.onWillNoteOff += (note) => {
                    PianoKeyLiftedUI(note.shortDisplayName);
                };
            }

        }

        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            midiDevice = device as Minis.MidiDevice;
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
                // Activate the Note
                each.GetComponent<Note_Mine>().isPressed = true;
                each.GetComponent<Note_Mine>().initialPress = true;

                currentPressedNotes.Add(each);
                each.GetComponent<SpriteRenderer>().color = Color.red;

                

            }
        }
    }

    void PianoKeyLiftedUI(string notePressed)
    {
        foreach (GameObject each in PianoKeys)
        {
            if (each.name == notePressed)
            {
                // Deactivate the Note
                each.GetComponent<Note_Mine>().isPressed = false;
                each.GetComponent<Note_Mine>().initialPress = false;

                currentPressedNotes.Remove(each);
                if (notePressed.Contains("#"))
                {
                    each.GetComponent<SpriteRenderer>().color = Color.black;
                }
                else
                {
                    each.GetComponent<SpriteRenderer>().color = Color.white;
                }

                
            }
        }
    }


}
