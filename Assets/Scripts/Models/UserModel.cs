using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserModel : MonoBehaviour
{
    public static UserModel user;

	private void Awake()
	{
		if (user != null && user != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			user = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public bool isLoggedIn;
	public string username;
    public string _id;
    public int money;
    public int level;
    public int exp;
    public bool purchased;
}
