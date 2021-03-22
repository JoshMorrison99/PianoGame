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

	public TextMeshProUGUI playerLevelUI;
	public TextMeshProUGUI playerMoneyUI;

	public Slider playerExpSliderUI;

	void Start()
	{
		// Player persistent data UI
		playerLevelUI.text = PersistentData.data.level.ToString();
		playerMoneyUI.text = PersistentData.data.money.ToString();

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
		playerExpSliderUI.maxValue = ReturnXPNeededToLevelUp(PersistentData.data.level);
		playerExpSliderUI.minValue = 0;
		playerExpSliderUI.value = PersistentData.data.exp;

    }

	int ReturnXPNeededToLevelUp(int level)
	{
		return (int)Mathf.Round((10 * (Mathf.Pow(level, 3))) / 5);
	}


}
