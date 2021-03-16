using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Button songSelectionBtn;
	public Button lessonsBtn;
	public Button settingsBtn;
	public Button accountBtn;

	public GameObject SongSelectionPanel;
	public GameObject SettingsMenuPanel;

	void Start()
	{
		Button btn = songSelectionBtn.GetComponent<Button>();
		btn.onClick.AddListener(songSelectionClicked);
	}

	public void showMainMenu()
    {
		SongSelectionPanel.SetActive(false);
	}

	public void songSelectionClicked()
    {
		SongSelectionPanel.SetActive(true);
	}


}
