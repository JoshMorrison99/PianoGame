using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NoteIdentificationGameUI : MonoBehaviour
{
    public NoteIdentificationGame game;

    public GameObject piano;

    public Button Play;
    public Button BackButton;
    public GameObject PausePanel;

    public TextMeshProUGUI BassTrebleTitle;
    public GameObject TrebleClefImage;
    public GameObject BassClefImage;

    public GameObject TrebleClefImage_Play;
    public GameObject BassClefImagee_Play;
    public GameObject WholeNotePlay;

    public GameObject bassOrTreblePanel;
    public GameObject noteRangePanel;
    public GameObject gamePanel;

    public GameObject WholeNoteImgTop;
    public GameObject WholeNoteImgBottom;
    public GameObject TopLine1;
    public GameObject TopLine2;
    public GameObject TopLine3;
    public GameObject TopLine4;

    public GameObject BottomLine1;
    public GameObject BottomLine2;
    public GameObject BottomLine3;
    public GameObject BottomLine4;

    public void Start()
    {
        PausePanel.SetActive(false);

        bassOrTreblePanel.SetActive(true);
        noteRangePanel.SetActive(false);
        gamePanel.SetActive(false);

        TopLine1.SetActive(true);
        TopLine2.SetActive(true);
        TopLine3.SetActive(true);
        TopLine4.SetActive(true);

        BottomLine1.SetActive(true);
        BottomLine2.SetActive(true);
        BottomLine3.SetActive(true);
        BottomLine4.SetActive(true);

        BackButton.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);

        SetPianoUI();
    }

    public void SetPianoUI()
    {
        if (PlayerPrefs.GetInt("PianoType") == 0) // 49 key piano
        {
            piano.transform.localPosition = new Vector3(1.4f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(21.2f, piano.transform.localScale.y, piano.transform.localScale.z);

        }
        else if (PlayerPrefs.GetInt("PianoType") == 1) // 61 key piano
        {
            piano.transform.localPosition = new Vector3(-0.6f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(17f, piano.transform.localScale.y, piano.transform.localScale.z);

        }
        else if (PlayerPrefs.GetInt("PianoType") == 2) // 76 key piano
        {
            piano.transform.localPosition = new Vector3(0.5f, piano.transform.localPosition.y, piano.transform.localPosition.z);
            piano.transform.localScale = new Vector3(13.6f, piano.transform.localScale.y, piano.transform.localScale.z);

        }
        else
        {
            Debug.Log("Error occured getting piano type UI");
        }
    }

    public void PauseButtonClicked()
    {
        PausePanel.SetActive(true);
    }

    public void ResumeButtonClicked()
    {
        PausePanel.SetActive(false);
    }

    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void BassClefButtonClicked()
    {
        game.isBass = true;
        bassOrTreblePanel.SetActive(false);
        noteRangePanel.SetActive(true);
        BackButton.gameObject.SetActive(true);
        Play.gameObject.SetActive(true);
        BassTrebleTitle.text = "Select Bass Range";
        BassClefImage.SetActive(true);
        TrebleClefImage.SetActive(false);

        game.topNote = "A3";
        game.topNoteIndex = 26;
        game.bottomNote = "G2";
        game.bottomNoteIndex = 18;
    }

    public void TrebleClefButtonClicked()
    {
        game.isBass = false;
        bassOrTreblePanel.SetActive(false);
        noteRangePanel.SetActive(true);
        BackButton.gameObject.SetActive(true);
        Play.gameObject.SetActive(true);
        BassTrebleTitle.text = "Select Treble Range";
        BassClefImage.SetActive(false);
        TrebleClefImage.SetActive(true);


        game.topNote = "F5";
        game.topNoteIndex = 38;
        game.bottomNote = "E4";
        game.bottomNoteIndex = 30;
    }

    public void BackButtonClicked()
    {
        bassOrTreblePanel.SetActive(true);
        noteRangePanel.SetActive(false);
        BackButton.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        WholeNoteImgBottom.transform.localPosition = new Vector2(WholeNoteImgBottom.transform.localPosition.x, -90);
        WholeNoteImgTop.transform.localPosition = new Vector2(WholeNoteImgTop.transform.localPosition.x, 90);
    }

    public void PlayButtonClicked()
    {
        bassOrTreblePanel.SetActive(false);
        noteRangePanel.SetActive(false);
        gamePanel.SetActive(true);
        BackButton.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);

        if (game.isBass)
        {
            BassClefImagee_Play.SetActive(true);
            TrebleClefImage_Play.SetActive(false);
        }
        else{
            BassClefImagee_Play.SetActive(false);
            TrebleClefImage_Play.SetActive(true);
        }

        game.StartGame(WholeNotePlay);
    }

    public void UpButtonTopClicked()
    {
        if (!game.isBass)
        {
            if (game.topNoteIndex >= 38 && game.topNoteIndex < 46)
            {
                Debug.Log("Bass - Up Button Pressed");
                game.topNoteIndex += 1;
                WholeNoteImgTop.transform.position = new Vector2(WholeNoteImgTop.transform.position.x, WholeNoteImgTop.transform.position.y + 11.25f );
            }
        }
        else
        {
            if (game.topNoteIndex >= 26 && game.topNoteIndex < 34)
            {
                Debug.Log("Trebel - Up Button Pressed");
                game.topNoteIndex += 1;
                WholeNoteImgTop.transform.position = new Vector2(WholeNoteImgTop.transform.position.x, WholeNoteImgTop.transform.position.y + 11.25f);
            }
        }
    }

    public void DownButtonTopClicked()
    {
        if (!game.isBass)
        {
            if (game.topNoteIndex > 38 && game.topNoteIndex <= 46)
            {
                Debug.Log("Bass - Down Button Pressed");
                game.topNoteIndex -= 1;
                WholeNoteImgTop.transform.position = new Vector2(WholeNoteImgTop.transform.position.x, WholeNoteImgTop.transform.position.y - 11.25f);
            }
        }
        else
        {
            if (game.topNoteIndex > 26 && game.topNoteIndex <= 34)
            {
                game.topNoteIndex -= 1;
                WholeNoteImgTop.transform.position = new Vector2(WholeNoteImgTop.transform.position.x, WholeNoteImgTop.transform.position.y - 11.25f);
            }
        }
    }

    public void UpButtonBottomClicked()
    {
        if (!game.isBass)
        {
            if (game.bottomNoteIndex >= 22 && game.bottomNoteIndex < 30)
            {
                Debug.Log("Bass - Up Button Pressed");
                game.bottomNoteIndex += 1;
                WholeNoteImgBottom.transform.position = new Vector2(WholeNoteImgBottom.transform.position.x, WholeNoteImgBottom.transform.position.y + 11.25f);
            }
        }
        else
        {
            if (game.bottomNoteIndex >= 10 && game.bottomNoteIndex < 18)
            {
                Debug.Log("Treble - Up Button Pressed");
                game.bottomNoteIndex += 1;
                WholeNoteImgBottom.transform.position = new Vector2(WholeNoteImgBottom.transform.position.x, WholeNoteImgBottom.transform.position.y + 11.25f);
            }
        }
    }

    public void DownButtonBottomClicked()
    {
        if (!game.isBass)
        {
            if (game.bottomNoteIndex > 22 && game.bottomNoteIndex <= 30)
            {
                Debug.Log("Bass - Down Button Pressed");
                game.bottomNoteIndex -= 1;
                WholeNoteImgBottom.transform.position = new Vector2(WholeNoteImgBottom.transform.position.x, WholeNoteImgBottom.transform.position.y - 11.25f);
            }
        }
        else
        {
            if (game.bottomNoteIndex > 10 && game.bottomNoteIndex <= 18)
            {
                Debug.Log("Treble - Up Button Pressed");
                game.bottomNoteIndex -= 1;
                WholeNoteImgBottom.transform.position = new Vector2(WholeNoteImgBottom.transform.position.x, WholeNoteImgBottom.transform.position.y - 11.25f);
            }
        }
    }


}
