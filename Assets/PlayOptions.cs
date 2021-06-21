using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayOptions : MonoBehaviour
{
    public Toggle StutterModeStrict;
    public Toggle StutterModeChill;
    public Toggle StubbornMode;
    public Toggle TimelineActivate;

    private void Start()
    {
        StutterModeStrict.isOn = PersistentData.data.StutterModeStrict;
        StutterModeChill.isOn = PersistentData.data.StutterModeChill;
        StubbornMode.isOn = PersistentData.data.StubbornMode;
        TimelineActivate.isOn = PersistentData.data.TimelineActivate;
    }

    public void StutterModeStrictToggled()
    {
        PersistentData.data.StutterModeStrict = StutterModeStrict.isOn;
        PersistentData.data.StutterModeChill = false;
        StutterModeChill.isOn = false;
    }

    public void StutterModeChillToggled()
    {
        PersistentData.data.StutterModeChill = StutterModeChill.isOn;
        PersistentData.data.StutterModeStrict = false;
        StutterModeStrict.isOn = false;
    }

    public void StubbornModeToggled()
    {
        PersistentData.data.StubbornMode = StubbornMode.isOn;
    }

    public void TimelineActivateToggled()
    {
        PersistentData.data.TimelineActivate = TimelineActivate.isOn;
    }

    public void PlayOptionsSettingsButtonClicked()
    {
        gameObject.SetActive(true);
    }

    public void PlayOptionsBackButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
