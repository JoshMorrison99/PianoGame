using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEditor;
using System.IO;
using System;
using SFB;
using UnityEngine.Networking;

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

	public Button songSelectionBtn;
	public Button lessonsBtn;
	public Button settingsBtn;
	public Button accountBtn;
	public Button quitBtn;
	public Button themesBtn;
	public Button gamesBtn;
	public Button freePlayBtn;

	public TextMeshProUGUI currentUserText;

	public GameObject Title;

	public GameObject SongSelectionPanel;
	public GameObject SettingsMenuPanel;
	public GameObject ThemesPanel;
	public GameObject AccountMenuPanel;
	public GameObject RegisterPanel;
	public GameObject LoginPanel;

	public TextMeshProUGUI MainMenu_playerLevelUI;
	public TextMeshProUGUI MainMenu_playerMoneyUI;
	public Slider MainMenu_playerExpSliderUI;

	public GameObject SongImportErrorMessagePanel;

	public SongSelection songSelectionClass;

	// Register Logic
	public TMP_InputField Register_UsernameInputField;
	public TextMeshProUGUI Register_UsernameError;
	public TMP_InputField Register_EmailInputField;
	public TextMeshProUGUI Register_EmailError;
	public TMP_InputField Register_PasswordInputField;
	public TextMeshProUGUI Register_PasswordError;
	public TMP_InputField Register_PasswordConfirmInputField;

	// Login Logic
	public TMP_InputField Login_EmailInputField;
	public TextMeshProUGUI Login_EmailError;
	public TMP_InputField Login_PasswordInputField;
	public TextMeshProUGUI Login_PasswordError;

	// Logout Logic
	public GameObject LogoutPanel;

	public string path;



	void Start()
	{
        if (PlayerPrefs.GetString("username") == "")
        {
			currentUserText.text = "Local";
        }
        else
        {
			currentUserText.text = PlayerPrefs.GetString("username");
		}

		AccountMenuPanel.SetActive(false);
		Register_EmailError.text = "";
		Register_PasswordError.text = "";
		Register_UsernameError.text = "";
		Login_EmailError.text = "";
		Login_PasswordError.text = "";

		SoundManager.soundManager.audioSource.volume = 0.1f;

		SongImportErrorMessagePanel.SetActive(false);
		SettingsMenuPanel.SetActive(false);
		SongSelectionPanel.SetActive(false);

		PlayerStatsLoad();

		Button btn = songSelectionBtn.GetComponent<Button>();
		btn.onClick.AddListener(songSelectionClicked);

		EXPSlideSetup();

		EnableMainMenuButtons();
		Title.SetActive(true);
		ThemesPanel.gameObject.SetActive(false);

	}

	public void showMainMenu()
    {
		SongSelectionPanel.SetActive(false);
		Title.SetActive(true);
		EnableMainMenuButtons();
		AccountMenuPanel.SetActive(false);
		ThemesPanel.gameObject.SetActive(false);

		// play button clcik sfx
		if (buttonClickedEvent != null)
		{
			buttonClickedEvent();
		}
	}

	public void LogoutButtonClicked()
    {
		PlayerPrefs.DeleteKey("userID");
		PlayerPrefs.DeleteKey("username");

		currentUserText.text = "Local";
		showMainMenu();
	}

	public void LoginButtonClickedValidation()
    {
		StartCoroutine(Login(Login_EmailInputField.text, Login_PasswordInputField.text));
    }

	IEnumerator Login(string email, string password)
	{
		Debug.Log("clicked");
		WWWForm form = new WWWForm();
		form.AddField("email", email);
		form.AddField("password", password);

		string url = "";
        if (Config.ENV == "development")
        {
			url = "http://localhost:5000/api/login";
        }
        else
        {
			url = "https://primepianist.com/api/login";
		}
		using (UnityWebRequest www = UnityWebRequest.Post(url, form))
		{
			yield return www.SendWebRequest();

			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(www.downloadHandler.text);
			}
			else
			{
				Debug.Log("Form upload complete!");
				User myUser = JsonUtility.FromJson<User>(www.downloadHandler.text);
				Debug.Log(www.downloadHandler.text);
				Debug.Log(myUser.email);
				AccountMenuPanel.SetActive(false);
				showMainMenu();
				currentUserText.text = myUser.username;
				PlayerPrefs.SetString("userID", myUser._id);
				PlayerPrefs.SetString("username", myUser.username);
				if (PlayerPrefs.GetString("userID") != "")
				{
					Debug.Log("here");
					StartCoroutine(SaveSong());
				}
			}
		}
	}

	public void RegisterButtonClickedValidation()
    {
		bool isError = false;

        if (Register_UsernameInputField.text.Length < 4)
        {
			Register_UsernameError.text = "Username must be 4 characters or longer";
			isError = true;
        }
        else
        {
			Register_UsernameError.text = "";
		}

        if (Register_EmailInputField.text == "")
        {
			Register_EmailError.text = "Email cannot be empty";
			isError = true;
		}else if (Register_EmailInputField.text.Contains("@") == false)
        {
			Register_EmailError.text = "Email must be a valid email";
			isError = true;
        }
        else
        {
			Register_EmailError.text = "";
		}

        if (Register_PasswordInputField.text.Length < 6)
        {
			Register_PasswordError.text = "Password must be 6 characters or longer";
			isError = true;
		}
		else if (Register_PasswordInputField.text != Register_PasswordConfirmInputField.text)
        {
			Register_PasswordError.text = "Password fields must match";
			isError = true;
        }
        else
        {
			Register_PasswordError.text = "";
		}

        if (!isError)
        {
			Debug.Log("Successful input");
			Debug.Log("username " + Register_UsernameInputField.text);
			Debug.Log("email " + Register_EmailInputField.text);
			Debug.Log("password " + Register_PasswordInputField.text);
			StartCoroutine(Register(Register_UsernameInputField.text, Register_EmailInputField.text, Register_PasswordInputField.text));
		}
    }

	IEnumerator Register(string username, string email, string password)
	{
		WWWForm form = new WWWForm();
		form.AddField("username", username);
		form.AddField("email", email);
		form.AddField("password", password);

		string url = "";
        if (Config.ENV == "development")
        {
			url = "http://localhost:5000/api/signup";
        }
        else
        {
			url = "https://primepianist.com/api/signup";
		}
		using (UnityWebRequest www = UnityWebRequest.Post(url, form))
		{
			yield return www.SendWebRequest();

			if (www.result != UnityWebRequest.Result.Success)
			{
				Register_UsernameError.text = "Username or Email already exist";
			}
			else
			{
				Debug.Log("Form upload complete!");
				User myUser = JsonUtility.FromJson<User>(www.downloadHandler.text);
				AccountMenuPanel.SetActive(false);
				showMainMenu();
				currentUserText.text = myUser.username;
				PlayerPrefs.SetString("userID", myUser._id);
				PlayerPrefs.SetString("username", myUser.username);
				if (PlayerPrefs.GetString("userID") != "")
				{
					Debug.Log("here");
					StartCoroutine(SaveSong());
				}
			}
		}
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

	public void AccountButtonClicked()
    {
        if (PlayerPrefs.GetString("userID") != "")
        {
			DisableMainMenuButtons();
			AccountMenuPanel.SetActive(true);
			LogoutPanel.SetActive(true);
			RegisterPanel.SetActive(false);
			LoginPanel.SetActive(false);
		}
        else
        {
			DisableMainMenuButtons();
			AccountMenuPanel.SetActive(true);
			RegisterPanel.SetActive(true);
			LoginPanel.SetActive(false);
			LogoutPanel.SetActive(false);
		}
		
	}

	public void RegisterButtonClicked()
    {
		RegisterPanel.SetActive(true);
		LoginPanel.SetActive(false);
    }

	public void LoginButtonClicked()
    {
		RegisterPanel.SetActive(false);
		LoginPanel.SetActive(true);
    }



	public void ThemesButtonClicked()
    {
		DisableMainMenuButtons();
		ThemesPanel.gameObject.SetActive(true);
	}

	public void DisableMainMenuButtons()
    {
		accountBtn.gameObject.SetActive(false);
		songSelectionBtn.gameObject.SetActive(false);
		settingsBtn.gameObject.SetActive(false);
		accountBtn.gameObject.SetActive(false);
		quitBtn.gameObject.SetActive(false);
		themesBtn.gameObject.SetActive(false);
		gamesBtn.gameObject.SetActive(false);
		freePlayBtn.gameObject.SetActive(false);

	}

	public void EnableMainMenuButtons()
	{
		accountBtn.gameObject.SetActive(true);
		songSelectionBtn.gameObject.SetActive(true);
		settingsBtn.gameObject.SetActive(true);
		accountBtn.gameObject.SetActive(true);
		quitBtn.gameObject.SetActive(true);
		themesBtn.gameObject.SetActive(true);
		gamesBtn.gameObject.SetActive(true);
		freePlayBtn.gameObject.SetActive(true);
	}


	private void EXPSlideSetup()
    {

		MainMenu_playerExpSliderUI.maxValue = ReturnXPNeededToLevelUp(PersistentData.data.level);
		MainMenu_playerExpSliderUI.minValue = 0;
		MainMenu_playerExpSliderUI.value = PersistentData.data.exp;

	}


	public void FreePlayButtonClicked()
    {
		SoundManager.soundManager.MainMenuMusic.Pause();
		SceneManager.LoadScene("FreePlay");
    }

	public void GamesButtonClicked()
    {
		SoundManager.soundManager.MainMenuMusic.Pause();
		SceneManager.LoadScene("Games");
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

	IEnumerator SaveSong()
	{

		SaveSongList mySaveSongs = new SaveSongList();
		mySaveSongs.Songs = new SaveSongInstance[50];
		foreach (SongInfo song in PersistentData.data._SongList)
		{
			Debug.Log("--> " + song._SongTitle);
			mySaveSongs.Songs[song._songID] = new SaveSongInstance();
			mySaveSongs.Songs[song._songID].author = song._SongAuthor;
			mySaveSongs.Songs[song._songID].title = song._SongTitle;
			mySaveSongs.Songs[song._songID].stars = song._stars;
			mySaveSongs.Songs[song._songID].songID = song._songID;
			mySaveSongs.Songs[song._songID].plays = song._plays;
			mySaveSongs.Songs[song._songID].percentage = song._songCompletionPercentage;
			mySaveSongs.Songs[song._songID].notesHit = song._notesHit;
			mySaveSongs.Songs[song._songID].totalNotes = song._totalNote;
			mySaveSongs.Songs[song._songID].highscore = song._highScore;
			mySaveSongs.Songs[song._songID].difficulty = song._Difficulty;
		}

		foreach (SaveSongInstance s in mySaveSongs.Songs)
		{
			Debug.Log("--------> " + s.title);
		}

		string json = JsonUtility.ToJson(mySaveSongs);

		string url = "";
        if (Config.ENV == "development")
        {
			url = "http://localhost:5000/api/songs?user=";
        }
        else
        {
			url = "https://primepianist.com/api/songs?user=";
		}
		using (UnityWebRequest www = UnityWebRequest.Put(url + PlayerPrefs.GetString("userID"), json))
		{
			www.SetRequestHeader("Accept", "application/json");
			www.SetRequestHeader("Content-Type", "application/json");
			www.method = UnityWebRequest.kHttpVerbPUT;
			yield return www.SendWebRequest();

			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(www.downloadHandler.text);
			}
			else
			{
				Debug.Log("Form upload complete!");
			}
		}
	}




}

[Serializable]
public class User
{
	public int money;
	public int level;
	public int exp;
	public string _id;
	public string username;
	public string email;
	public string password;
}

[Serializable]
class SaveSongInstance
{
	public int songID;
	public string title;
	public string author;
	public int highscore;
	public int plays;
	public string stars;
	public int totalNotes;
	public float notesHit;
	public float percentage;
	public string difficulty;
}

[Serializable]
class SaveSongList
{
	public SaveSongInstance[] Songs;
}
