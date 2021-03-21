using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

public class DeviceFinder : MonoBehaviour
{
    // Start is called before the first frame update

    public static DeviceFinder device;

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
        

        Debug.Log(InputSystem.devices);


        InputSystem.onDeviceChange += (device, change) =>
        {
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            Debug.Log(string.Format("{0} ({1}) {2}",
                device.description.product, midiDevice.channel, change));
        };
    }
}
