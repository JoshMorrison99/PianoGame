using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Shop : MonoBehaviour
{
    // SHOP MAIN BUTTON
    public Button main_NotesButton;
    public Button main_ParticlesButton;
    public Button main_PianoBarButton;
    public Button main_LightsButton;

    // SHOP MAIN PANELS
    public GameObject main_NotesShop;
    public GameObject main_ParticlesShop;
    public GameObject main_PianoBarShop;
    public GameObject main_LightsShop;

    // SHOP BUTTON ANIMATION LOGIC
    public bool NotesButton_isCurrent = false;
    public bool ParticlesButton_isCurrent = false;
    public bool PianoBarButton_isCurrent = false;
    public bool LightsButton_isCurrent = false;
    
    public void NotesShopButtonClicked()
    {
        if (NotesButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(true);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            NotesButton_isCurrent = false;
        }
        else
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(0, -400, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(true);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            NotesButton_isCurrent = true;
        }
        
    }

    public void ParticlesShopButtonClicked()
    {
        if (ParticlesButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(true);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            ParticlesButton_isCurrent = false;
        }
        else{
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(0, -400, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(true);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            ParticlesButton_isCurrent = true;
        }
        
    }

    public void PianoBarButtonClicked()
    {
        if (PianoBarButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(true);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            PianoBarButton_isCurrent = false;
        }
        else
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(0, -400, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(true);
            main_LightsShop.SetActive(false);

            PianoBarButton_isCurrent = true;
        }
        
    }

    public void LightsButtonClicked()
    {
        if (LightsButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(true);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            LightsButton_isCurrent = false;
        }
        else
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(0, -400, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(true);

            LightsButton_isCurrent = true;
        }
        
    }


    
}
