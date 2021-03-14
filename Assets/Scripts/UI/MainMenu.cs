using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Button playBtn;
    public Button settingsBtn;

	public GameObject SongSelectionPanel;
	public GameObject SettingsMenuPanel;

	void Start()
	{
		Button btn = playBtn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
	}

	public void showMainMenu()
    {
		SongSelectionPanel.SetActive(false);
	}

}
