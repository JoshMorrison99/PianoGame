using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEditor;
using System.IO;
using System;
using SFB;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class MainMenu : MonoBehaviour
{

	readonly string postSignupURL_Debug = "http://localhost:5000/api/signup";
	readonly string postLoginURL_Debug = "http://localhost:5000/api/login";

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

	// Account
	public GameObject CreateAccountGameObject;
	public GameObject LoginAccountGameObject;
	public TextMeshProUGUI usernameUI;

	// Account Signup
	public TMP_InputField usernameSignup;
	public TMP_InputField emailSignup;
	public TMP_InputField passwordSignup;
	public TMP_InputField re_passwordSignup;
	public TextMeshProUGUI usernameSignupErrorText;
	public TextMeshProUGUI emailSignupErrorText;
	public TextMeshProUGUI passwordSignupErrorText;

	// Account Login
	public TMP_InputField usernameLogin;
	public TMP_InputField passwordLogin;
	public TextMeshProUGUI usernameLoginError;
	public TextMeshProUGUI passwordLoginError;

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

		LoginAccountGameObject.SetActive(false);
		CreateAccountGameObject.SetActive(true);
		usernameSignupErrorText.text = "";
		emailSignupErrorText.text = "";
		passwordSignupErrorText.text = "";

		usernameLoginError.text = "";
		passwordLoginError.text = "";
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

	public void DontHaveAccountSignUpClicked()
    {
		LoginAccountGameObject.SetActive(false);
		CreateAccountGameObject.SetActive(true);
    }

	public void HaveAccountLoginClicked()
    {
		CreateAccountGameObject.SetActive(false);
		LoginAccountGameObject.SetActive(true);
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

	public void LoginButtonClicked()
    {
		Debug.Log("Login user");
		StartCoroutine(LoginRequest());
	}

	IEnumerator LoginRequest()
    {
		LoginModel loginModel = new LoginModel();
		loginModel.username = usernameLogin.text;
		loginModel.password = passwordLogin.text;

		string json = JsonConvert.SerializeObject(loginModel);

		Debug.Log(json);

		using (UnityWebRequest www = UnityWebRequest.Post(postLoginURL_Debug, json))
		{
			var byteJSON = System.Text.Encoding.UTF8.GetBytes(json);
			www.method = UnityWebRequest.kHttpVerbPOST;
			www.uploadHandler = (UploadHandler)new UploadHandlerRaw(byteJSON);
			www.SetRequestHeader("Content-Type", "application/json");
			www.SetRequestHeader("Accept", "application/json");
			yield return www.SendWebRequest();


			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(www.downloadHandler.text);
				JObject o = JObject.Parse(www.downloadHandler.text);
				Debug.Log(o["errors"]["username"]);
				Debug.Log(o["errors"]["password"]);
				if (o["errors"]["username"].ToString() != "")
				{
					usernameLoginError.text = o["errors"]["username"].ToString();

				}
				else
				{
					usernameLoginError.text = "";
				}

				if (o["errors"]["password"].ToString() != "")
				{
					passwordLoginError.text = o["errors"]["password"].ToString();
				}
				else
				{
					passwordLoginError.text = "";
				}
			}
			else
			{
				Debug.Log("Form upload complete!");
				CreateAccountGameObject.SetActive(false);
				LoginAccountGameObject.SetActive(false);

				// Store username and user id
				Debug.Log(www.downloadHandler.text);
				JObject o = JObject.Parse(www.downloadHandler.text);
				PlayerPrefs.SetString("user_id", o["_id"].ToString());
				PlayerPrefs.SetString("user_username", o["username"].ToString());
				PlayerPrefs.SetString("user_loggedin", "true");

				// Set ui
				usernameUI.text = o["username"].ToString();
			}
		}
	}


	public void SignUpButtonClicked()
    {
		bool error = false;
        // Simple unity side error handling
        if (usernameSignup.text == "")
        {
			error = true;
			usernameSignupErrorText.text = "username cannot be empty";
        }
        else
        {
			usernameSignupErrorText.text = "";
        }

		if (emailSignup.text == "")
        {
			error = true;
			emailSignupErrorText.text = "email cannot be empty";
        }
        else
        {
			emailSignupErrorText.text = "";
		}


		if (passwordSignup.text != re_passwordSignup.text)
        {
			error = true;
			passwordSignupErrorText.text = "password must match the re-entered password";
        }
        else
        {
			passwordSignupErrorText.text = "";
		}


		Debug.Log(error);
        if (error == false)
        {
			Debug.Log("Signing user up");
			StartCoroutine(SignUpRequest());
		}
		
    }

	IEnumerator SignUpRequest()
    {
		SignupModel signupModel = new SignupModel();
		signupModel.username = usernameSignup.text;
		signupModel.email = emailSignup.text;
		signupModel.password = passwordSignup.text;

		string json = JsonConvert.SerializeObject(signupModel);

		Debug.Log(json);
		

		using (UnityWebRequest www = UnityWebRequest.Post(postSignupURL_Debug, json))
		{
			var byteJSON = System.Text.Encoding.UTF8.GetBytes(json);
			www.method = UnityWebRequest.kHttpVerbPOST;
			www.uploadHandler = (UploadHandler)new UploadHandlerRaw(byteJSON);
			www.SetRequestHeader("Content-Type", "application/json");
			www.SetRequestHeader("Accept", "application/json");
			yield return www.SendWebRequest();


			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log(www.downloadHandler.text);
				JObject o = JObject.Parse(www.downloadHandler.text);
				Debug.Log(o["errors"]["username"]);
				Debug.Log(o["errors"]["email"]);
				Debug.Log(o["errors"]["password"]);
                if (o["errors"]["username"].ToString() != "")
                {
					usernameSignupErrorText.text = o["errors"]["username"].ToString();

				}
                else
                {
					usernameSignupErrorText.text = "";
				}

                if (o["errors"]["email"].ToString() != "")
                {
					emailSignupErrorText.text = o["errors"]["email"].ToString();
				}
                else
                {
					emailSignupErrorText.text = "";
				}

                if (o["errors"]["password"].ToString() != "")
                {
					passwordSignupErrorText.text = o["errors"]["password"].ToString();
                }
                else
                {
					passwordSignupErrorText.text = "";
				}
			}
			else
			{
				Debug.Log("Form upload complete!");
				CreateAccountGameObject.SetActive(false);
				LoginAccountGameObject.SetActive(false);

				// Store username and user id
				Debug.Log(www.downloadHandler.text);
				JObject o = JObject.Parse(www.downloadHandler.text);
				PlayerPrefs.SetString("user_id", o["_id"].ToString());
				PlayerPrefs.SetString("user_username", o["username"].ToString());
				PlayerPrefs.SetString("user_loggedin", "true");

				// Set ui
				usernameUI.text = o["username"].ToString();
			}
		}
	}


}


