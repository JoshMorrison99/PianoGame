using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
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



	void Start()
	{

		SettingsMenuPanel.SetActive(false);
		SongSelectionPanel.SetActive(false);

		PlayerStatsLoad();

		Button btn = songSelectionBtn.GetComponent<Button>();
		btn.onClick.AddListener(songSelectionClicked);

		EXPSlideSetup();
	}

	public void showMainMenu()
    {
		SongSelectionPanel.SetActive(false);
	}

	public void songSelectionClicked()
    {
		SongSelectionPanel.SetActive(true);
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
    }

	public void BackButtonSettings()
    {
		SettingsMenuPanel.SetActive(false);
    }


}
