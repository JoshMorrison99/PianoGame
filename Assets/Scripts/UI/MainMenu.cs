using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor;
using System.IO;
using System;
using SFB;

public class MainMenu : MonoBehaviour
{

	public string converArrayStringToString;
	public string covertWindowsStringToStandalone;


	public delegate void ButtonClickedAction();
	public static event ButtonClickedAction buttonClickedEvent;

	public delegate void ButtonClickedErrorAction();
	public static event ButtonClickedErrorAction buttonClickedErrorEvent;

	public delegate void ButtonClickedHoverAction();
	public static event ButtonClickedHoverAction buttonClickedHoverEvent;

	public delegate void ButtonClickedSuccessAction();
	public static event ButtonClickedSuccessAction buttonClickedSuccessEvent;

	public GameObject NotesShopHolder;
	public GameObject PianoBarShopHolder;
	public GameObject KeysShopHolder;

	public GameObject NotesRootHolder;
	public GameObject PianoBarRootHolder;
	public GameObject KeysRootHolder;

	public GameObject NotesHolderHolder;
	public GameObject PianoBarHolderHolder;
	public GameObject KeysHolderHolder;


	public Button songSelectionBtn;
	public Button lessonsBtn;
	public Button settingsBtn;
	public Button accountBtn;
	public Button quitBtn;
	public Button shopBtn;

	public GameObject Title;

	public GameObject ShopPanel;

	public GameObject SongSelectionPanel;
	public GameObject SettingsMenuPanel;


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

		EnableMainMenuButtons();
		Title.SetActive(true);
		ShopPanel.SetActive(false);


		Debug.Log("LOADING DATA MAIN MENU AGAIN");
		PersistentData.LoadJsonData(PersistentData.data);

	}

	public void showMainMenu()
    {
		SongSelectionPanel.SetActive(false);
		Title.SetActive(true);
		EnableMainMenuButtons();
		ShopPanel.SetActive(false);

		// play button clcik sfx
		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}

		NotesRootHolder.transform.SetParent(NotesHolderHolder.transform);


		PianoBarRootHolder.transform.SetParent(PianoBarHolderHolder.transform);

		KeysRootHolder.transform.SetParent(KeysHolderHolder.transform);
	}

	public void songSelectionClicked()
    {
		SongSelectionPanel.SetActive(true);
		DisableMainMenuButtons();
		Title.gameObject.SetActive(false);

		// play button clcik sfx
		if (buttonClickedEvent != null)
        {
			buttonClickedEvent();
        }
		
	}

	public void DisableMainMenuButtons()
    {
		accountBtn.gameObject.SetActive(false);
		songSelectionBtn.gameObject.SetActive(false);
		shopBtn.gameObject.SetActive(false);
		settingsBtn.gameObject.SetActive(false);
		accountBtn.gameObject.SetActive(false);
		quitBtn.gameObject.SetActive(false);
    }

	public void EnableMainMenuButtons()
	{
		accountBtn.gameObject.SetActive(true);
		songSelectionBtn.gameObject.SetActive(true);
		shopBtn.gameObject.SetActive(true);
		settingsBtn.gameObject.SetActive(true);
		accountBtn.gameObject.SetActive(true);
		quitBtn.gameObject.SetActive(true);
	}


	private void EXPSlideSetup()
    {

		MainMenu_playerExpSliderUI.maxValue = ReturnXPNeededToLevelUp(PersistentData.data.level);
		MainMenu_playerExpSliderUI.minValue = 0;
		MainMenu_playerExpSliderUI.value = PersistentData.data.exp;

	}

	public void OnShopButtonClicked()
    {
		ShopPanel.SetActive(true);
		DisableMainMenuButtons();
		Title.SetActive(false);


		NotesRootHolder.transform.SetParent(NotesShopHolder.transform);
		NotesRootHolder.transform.localPosition = new Vector3(0,0,0);

		PianoBarRootHolder.transform.SetParent(PianoBarShopHolder.transform);
		PianoBarRootHolder.transform.localPosition = new Vector3(0, 0, 0);

		KeysRootHolder.transform.SetParent(KeysShopHolder.transform);
		KeysRootHolder.transform.localPosition = new Vector3(0, 0, 0);
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
		MainMenu_playerLevelUI.text = "Level " + PersistentData.data.level.ToString();
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

		Title.SetActive(false);
		DisableMainMenuButtons();

	}

	public void QuitApplication()
    {
		Application.Quit();
    }

	public void BackButtonSettings()
    {
		SettingsMenuPanel.SetActive(false);

		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}

	}

	public string ConvertStringArrToString(string[] stringArr)
    {
		
        foreach (string str in stringArr)
        {
			converArrayStringToString += str;
        }
		Debug.Log(converArrayStringToString);
		return converArrayStringToString;

	}

	public string ConvertWindowsPathToStandalone(string str)
    {
        foreach (char i in str)
        {
			if (i.Equals('\\'))
            {
				Debug.Log("EQUAL");
				covertWindowsStringToStandalone += "/";
            }
            else
            {
				covertWindowsStringToStandalone += i;
			}
        }
		Debug.Log(covertWindowsStringToStandalone);
		return covertWindowsStringToStandalone;
    }

	public void ImportSongButtonClicked()
    {
		// play button clicked sfx
		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}

		
		string[] pathArr = StandaloneFileBrowser.OpenFilePanel("Open File", "", "mid", false);
		//path = EditorUtility.OpenFilePanel("user imported midi", "", "mid");

		string path = ConvertStringArrToString(pathArr);
		path = ConvertWindowsPathToStandalone(path);


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
			string ResourcesPath = Application.streamingAssetsPath + "/MidiFiles/UserMidiFiles";

			Debug.Log("PATH __ " + path);
			int pos = path.LastIndexOf("/") + 1;
			string fileName = path.Substring(pos, path.Length - pos);
			Debug.Log("FILENAME __ " + fileName);

			//check if file already exists
			if (File.Exists(ResourcesPath + "/" + fileName))
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
					File.Copy(path, ResourcesPath + "/" + fileName);

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


