using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using TMPro;
using UnityEngine.SceneManagement;

public class DeviceFinder : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void DeviceAdded();
    public static event DeviceAdded DeviceAddedEvent;

    public static DeviceFinder device;
    public Minis.MidiDevice midiDevice;
    public TextMeshProUGUI PianoUnpluggErrorText = null;

    private void Awake()
    {
        if (device != null && device != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            device = this;
            DontDestroyOnLoad(gameObject);

        }
    }


    void Start()
    {
        
        

        PianoUnpluggErrorText.gameObject.SetActive(false);


        InputSystem.EnableDevice(Mouse.current);
        foreach(var device in InputSystem.devices)
        {
            Debug.Log(device.displayName);
            
        }

        
        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            //midiDevice = device as Minis.MidiDevice;
            //Debug.Log(midiDevice.displayName);
            Debug.Log("CHANGE");
            switch (change)
            {
                case InputDeviceChange.Added:
                    // New Device.
                    Debug.Log("Device Added: " + device);
                    midiDevice = device as Minis.MidiDevice;
                    if (DeviceAddedEvent != null)
                    {
                        DeviceAddedEvent();
                    }
                    
                    StartCoroutine(PianoSuccessText());
                    //InputSystem.DisableDevice(device);
                    break;
                case InputDeviceChange.Disconnected:
                    // Device got unplugged.
                    Debug.Log("Device Disconnected: " + device);
                    StartCoroutine(PianoErrorText());
                    break;
                case InputDeviceChange.Reconnected:
                    // Plugged back in.
                    Debug.Log("Device Reconned: " + device);
                    break;
                case InputDeviceChange.Removed:
                    Debug.Log("Device Removed: " + device);
                    if (this != null)
                    {
                        StartCoroutine(PianoErrorText());
                    }
                    
                    // Remove from Input System entirely; by default, Devices stay in the system once discovered.
                    break;
                default:
                    // See InputDeviceChange reference for other event types.
                    break;
            }
        };


    }

    public void GetPianoDeviceErrorText()
    {
        PianoUnpluggErrorText = GameObject.Find("Piano error text").GetComponent<TextMeshProUGUI>();
        PianoUnpluggErrorText.gameObject.SetActive(false);
        

    }


    public IEnumerator PianoErrorText()
    {
        PianoUnpluggErrorText.gameObject.SetActive(true);
        PianoUnpluggErrorText.text = "Piano Disconnected";
        PianoUnpluggErrorText.color = Color.red;
        yield return new WaitForSeconds(5);
        PianoUnpluggErrorText.gameObject.SetActive(false);
    }

    public IEnumerator PianoSuccessText()
    {

        PianoUnpluggErrorText.gameObject.SetActive(true);
        PianoUnpluggErrorText.text = "Piano Connected";
        PianoUnpluggErrorText.color = Color.green;
        yield return new WaitForSeconds(5);
        PianoUnpluggErrorText.gameObject.SetActive(false);
    }
}
