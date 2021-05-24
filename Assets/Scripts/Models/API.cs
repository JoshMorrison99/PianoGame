using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour
{

	public static API api;

    private void Awake()
	{
		if (api != null && api != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			api = this;
			DontDestroyOnLoad(gameObject);
		}

		if (PlayerPrefs.HasKey("user_username"))
		{
			GetUser(PlayerPrefs.GetString("user_id"));
		}
	}

	readonly string User_URL_Debug = "http://localhost:5000/api/user";

	public void GetUser(string userID)
    {
		StartCoroutine(GetUserHelper(userID));
	}

	IEnumerator GetUserHelper(string userID)
    {
		using (UnityWebRequest www = UnityWebRequest.Get(User_URL_Debug + "?id=" + userID))
		{
			Debug.Log(User_URL_Debug + "?id=" + userID);
			www.method = UnityWebRequest.kHttpVerbGET;
			yield return www.SendWebRequest();


			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log("Failed to get user!");
				Debug.Log(www.downloadHandler.text);
				UserModel.user.isLoggedIn = false;
			}
			else
			{
				Debug.Log("Form upload complete!");
				Debug.Log(www.downloadHandler.text);
				JObject o = JObject.Parse(www.downloadHandler.text);
				UserModel.user.username = o["username"].ToString();
				UserModel.user._id = o["_id"].ToString();
				UserModel.user.money = (int)o["money"];
				UserModel.user.exp = (int)o["exp"];
				UserModel.user.level = (int)o["level"];
				UserModel.user.purchased = (bool)o["purchased"];
				UserModel.user.isLoggedIn = true;
			}
		}
	}

	public void PutUser(string userID, UpdateModel update)
	{

		string json = JsonConvert.SerializeObject(update);

		StartCoroutine(PutUserHelper(userID, json));
	}

	IEnumerator PutUserHelper(string userID, string json)
	{
		using (UnityWebRequest www = UnityWebRequest.Put(User_URL_Debug + "?id=" + userID, json))
		{
			var byteJSON = System.Text.Encoding.UTF8.GetBytes(json);
			www.method = UnityWebRequest.kHttpVerbPUT;
			www.uploadHandler = (UploadHandler)new UploadHandlerRaw(byteJSON);
			www.SetRequestHeader("Content-Type", "application/json");
			www.SetRequestHeader("Accept", "application/json");
			Debug.Log(User_URL_Debug + "?id=" + userID);
			yield return www.SendWebRequest();


			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.Log("Failed to get user!");
				Debug.Log(www.downloadHandler.text);
			}
			else
			{
				Debug.Log("Form upload complete!");
				Debug.Log(www.downloadHandler.text);
			}
		}
	}

}
