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


        InputSystem.EnableDevice(Mouse.current);
        
        /*InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    // New Device.
                    Debug.Log("Device Added: " + device);
                    //InputSystem.DisableDevice(device);
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
        };*/


    }
}
