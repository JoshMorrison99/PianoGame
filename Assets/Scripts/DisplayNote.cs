using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayNote : MonoBehaviour
{
    Minis.MidiDevice midiDevice;
    public TMP_Text displayNoteText;
    

    // Start is called before the first frame update
    void Start()
    {
        Settings.SettingsChanged += DisplayNoteLogic;
        DeviceFinder.DeviceAddedEvent += AddDevices;
        DisplayNoteLogic();
    }

    void DisplayNoteLogic()
    {
        displayNoteText.text = "";

        if (DeviceFinder.device.midiDevice != null)
        {
            AddDevices();
        }

        /*foreach (var each in InputSystem.devices)
        {
            if (each.displayName != "Mouse")
            {
                midiDevice = each as Minis.MidiDevice;
                Debug.Log("FOUND:" + midiDevice);

                midiDevice.onWillNoteOn += (note, velocity) => {
                    if (SceneManager.GetActiveScene().name == "Play")
                    {
                        if (PlayerPrefs.GetInt("isKeyPressLabel") == 1)
                        {
                            displayNoteText.text = note.shortDisplayName;
                        }
                        else
                        {
                            displayNoteText.text = "";
                        }
                    }
                };

                midiDevice.onWillNoteOff += (note) => {

                };
            }

        }*/

        

        
    }

    public void AddDevices()
    {
        DeviceFinder.device.midiDevice.onWillNoteOn += (note, velocity) => {
            if (SceneManager.GetActiveScene().name == "Play")
            {
                if (PlayerPrefs.GetInt("isKeyPressLabel") == 1)
                {
                    displayNoteText.text = note.shortDisplayName;
                }
                else
                {
                    displayNoteText.text = "";
                }
            }
        };

        DeviceFinder.device.midiDevice.onWillNoteOff += (note) => {
            //displayNoteText.text = " ";
        };
    }
}
