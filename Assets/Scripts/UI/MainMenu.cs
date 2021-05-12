using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{

	public GameObject comingSoonOBJ;
	bool activeComingSoon;

	public delegate void ButtonClickedAction();
	public static event ButtonClickedAction buttonClickedEvent;

	public delegate void ButtonClickedErrorAction();
	public static event ButtonClickedErrorAction buttonClickedErrorEvent;

	public delegate void ButtonClickedHoverAction();
	public static event ButtonClickedHoverAction buttonClickedHoverEvent;

	public delegate void ButtonClickedSuccessAction();
	public static event ButtonClickedSuccessAction buttonClickedSuccessEvent;


	public Button songSelectionBtn;
	public Button lessonsBtn;
	public Button settingsBtn;
	public Button accountBtn;


	public GameObject SongSelectionPanel;
	public GameObject SettingsMenuPanel;

	public TextMeshProUGUI SongSelection_playerLevelUI;
	public TextMeshProUGUI SongSelection_playerMoneyUI;
	public Slider SongSelection_playerExpSliderUI;

	public TextMeshProUGUI Settings_playerLevelUI;
	public TextMeshProUGUI Settings_playerMoneyUI;
	public Slider Settings_playerExpSliderUI;

	public TextMeshProUGUI MainMenu_playerLevelUI;
	public TextMeshProUGUI MainMenu_playerMoneyUI;
	public Slider MainMenu_playerExpSliderUI;

	public GameObject SongImportErrorMessagePanel;

	public SongSelection songSelectionClass;

	public string path;



	void Start()
	{
		SongImportErrorMessagePanel.SetActive(false);
		SettingsMenuPanel.SetActive(false);
		SongSelectionPanel.SetActive(false);

		PlayerStatsLoad();

		Button btn = songSelectionBtn.GetComponent<Button>();
		btn.onClick.AddListener(songSelectionClicked);

		EXPSlideSetup();

		comingSoonOBJ.SetActive(false);
		activeComingSoon = false;
	}

	public void showMainMenu()
    {
		SongSelectionPanel.SetActive(false);

		// play button clcik sfx
		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}
	}

	public void songSelectionClicked()
    {
		SongSelectionPanel.SetActive(true);

		// play button clcik sfx
		if (buttonClickedEvent != null)
        {
			buttonClickedEvent();
        }
		
	}

	private void EXPSlideSetup()
    {
		SongSelection_playerExpSliderUI.maxValue = ReturnXPNeededToLevelUp(PersistentData.data.level);
		SongSelection_playerExpSliderUI.minValue = 0;
		SongSelection_playerExpSliderUI.value = PersistentData.data.exp;

		Settings_playerExpSliderUI.maxValue = ReturnXPNeededToLevelUp(PersistentData.data.level);
		Settings_playerExpSliderUI.minValue = 0;
		Settings_playerExpSliderUI.value = PersistentData.data.exp;

		MainMenu_playerExpSliderUI.maxValue = ReturnXPNeededToLevelUp(PersistentData.data.level);
		MainMenu_playerExpSliderUI.minValue = 0;
		MainMenu_playerExpSliderUI.value = PersistentData.data.exp;

	}

	public void HelpImportSongBtnClicked()
    {
		string website = "http://localhost:3000/tutorial";
		Application.OpenURL(website);

		// play button clcik sfx
		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}
	}

	private void PlayerStatsLoad()
    {
		// Player persistent data UI
		SongSelection_playerLevelUI.text = PersistentData.data.level.ToString();
		SongSelection_playerMoneyUI.text = PersistentData.data.money.ToString();

		// Player persistent data UI
		Settings_playerLevelUI.text = PersistentData.data.level.ToString();
		Settings_playerMoneyUI.text = PersistentData.data.money.ToString();

		// Player persistent data UI
		MainMenu_playerLevelUI.text = PersistentData.data.level.ToString();
		MainMenu_playerMoneyUI.text = PersistentData.data.money.ToString();
	}

	int ReturnXPNeededToLevelUp(int level)
	{
		return (int)Mathf.Round((10 * (Mathf.Pow(level, 3))) / 5);
	}

	public void SettingsButtonClicked()
    {
		SettingsMenuPanel.SetActive(true);
		SettingsMenuPanel.GetComponent<Settings>().StartupApplyButton();

		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}

	}

	public void BackButtonSettings()
    {
		SettingsMenuPanel.SetActive(false);

		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}

	}

	public void LessonsOrAccountComingSoonSelect()
    {
        if (activeComingSoon == false)
        {
			StartCoroutine(ComingSoon());
		}
		
    }

	public IEnumerator ComingSoon()
    {
		activeComingSoon = true;
		comingSoonOBJ.SetActive(true);
		yield return new WaitForSeconds(1f);
		comingSoonOBJ.SetActive(false);
		activeComingSoon = false;
	}

	public void ImportSongButtonClicked()
    {
		// play button clicked sfx
		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}

		path = EditorUtility.OpenFilePanel("user imported midi", "", "mid");

        if (path == "")
        {
			return;
        }

		// Check if file is a midi file
        if (Path.GetExtension(path) != ".mid")
        {
			// PRINT ERROR TO USER THE THE FILE MUST BE A MIDI FILE
			Debug.Log("File must be a midi file");
			SongImportErrorMessagePanel.SetActive(true);
			SongImportErrorMessagePanel.GetComponent<Image>().color = Color.red;
			SongImportErrorMessagePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Error: File must be a .mid file";
			StartCoroutine(SpawnErrorMessage());

			// play button error clicked sfx
			if (buttonClickedErrorEvent != null)
			{
				buttonClickedErrorEvent();
			}

		}
        else
        {
			string ResourcesPath = "Assets/MidiFiles/UserMidiFiles";

			int pos = path.LastIndexOf("/") + 1;
			string fileName = path.Substring(pos, path.Length - pos);

			//check if file already exists
			if(File.Exists(ResourcesPath + "/" + fileName))
            {
				// PRINT ERROR TO USER THAT THE FILE ALREADY EXISTS
				Debug.Log("File already exists");
				SongImportErrorMessagePanel.SetActive(true);
				SongImportErrorMessagePanel.GetComponent<Image>().color = Color.red;
				SongImportErrorMessagePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Error: File already exists";
				StartCoroutine(SpawnErrorMessage());

				// play button error clicked sfx
				if (buttonClickedErrorEvent != null)
				{
					buttonClickedErrorEvent();
				}
			}
            else
            {
				try
				{
					FileUtil.CopyFileOrDirectory(path, ResourcesPath + "/" + fileName);

				}
				catch (Exception e)
				{
					SongImportErrorMessagePanel.SetActive(true);
					SongImportErrorMessagePanel.GetComponentInChildren<TextMeshProUGUI>().text = e.ToString();
					StartCoroutine(SpawnErrorMessage());
				}

				SongImportErrorMessagePanel.SetActive(true);
				SongImportErrorMessagePanel.GetComponent<Image>().color = Color.green;
				SongImportErrorMessagePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Success: Song imported";
				StartCoroutine(SpawnErrorMessage());

				songSelectionClass.ImportUserSong(fileName);

				// play success sfx
                if (buttonClickedSuccessEvent != null)
                {
					buttonClickedSuccessEvent();
                }

			}

			
		}

		
	}


	IEnumerator SpawnErrorMessage()
	{
		// suspend execution for 5 seconds
		yield return new WaitForSeconds(5);
		SongImportErrorMessagePanel.SetActive(false);
	}

}
