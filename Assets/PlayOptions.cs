using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayOptions : MonoBehaviour
{
    public Toggle SheetMusicViewer;

    public void PlayOptionsSheetMusicViewerToggled()
    {

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
