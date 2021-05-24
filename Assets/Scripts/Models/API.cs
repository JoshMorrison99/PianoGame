using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class API : MonoBehaviour
{

	public static API api;

	private void Awake()
	{

		//data = this;

		if (api != null && api != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			api = this;
			DontDestroyOnLoad(gameObject);
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
			}
			else
			{
				Debug.Log("Form upload complete!");
				Debug.Log(www.downloadHandler.text);
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
