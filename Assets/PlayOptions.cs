using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayOptions : MonoBehaviour
{
    public Toggle StutterMode;
    public Toggle StubbornMode;
    public Toggle TimelineActivate;


    public void StutterModeToggled()
    {
        PersistentData.data.StutterMode = StutterMode.isOn;
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
