using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Themes : MonoBehaviour
{
    public GameObject ContentScrollView;

    public string themeName;
    public Color NoteLightColor;
    public Color SharpNoteLightColor;
    public Color NoteColor;
    public Color SharpNoteColor;
    public VideoClip TopBar;
    public Color KeyColor;

    private void Start()
    {
        foreach (Transform theme in ContentScrollView.transform)
        {
            if (PersistentData.data.ThemeName == theme.GetComponent<Themes>().themeName)
            {
                Debug.Log("Theme " + PersistentData.data.ThemeName + " is equal");
                theme.gameObject.GetComponent<Image>().color = new Color(255f / 255f, 0f / 255f, 0f / 255f, 160f / 255f);
                PersistentData.data.ThemeKeyColor = theme.GetComponent<Themes>().KeyColor;
                PersistentData.data.ThemeNoteColor = theme.GetComponent<Themes>().NoteColor;
                PersistentData.data.ThemePianoBar = theme.GetComponent<Themes>().TopBar;
                PersistentData.data.ThemeSharpNoteColor = theme.GetComponent<Themes>().SharpNoteColor;
                PersistentData.data.SharpNoteLightColor = theme.GetComponent<Themes>().SharpNoteLightColor;
                PersistentData.data.NoteLightColor = theme.GetComponent<Themes>().NoteLightColor;
                break;
            }
        }
    }

    public void OnClick()
    {
        PersistentData.data.ThemeName = themeName;
        PersistentData.data.ThemeKeyColor = KeyColor;
        PersistentData.data.ThemeNoteColor = NoteColor;
        PersistentData.data.ThemePianoBar = TopBar;
        PersistentData.data.ThemeSharpNoteColor = SharpNoteColor;
        PersistentData.data.SharpNoteLightColor = SharpNoteLightColor;
        PersistentData.data.NoteLightColor = NoteLightColor;

        foreach (Transform theme in ContentScrollView.transform)
        {
            theme.gameObject.GetComponent<Image>().color = new Color(60f / 255f, 60f / 255f, 60f / 255f, 60f / 255f);
        }

        gameObject.GetComponent<Image>().color = new Color(255f/255f, 0f/255f, 0f/255f, 160f / 255f);

        PlayerPrefs.SetString("Theme", themeName);
    }
}
