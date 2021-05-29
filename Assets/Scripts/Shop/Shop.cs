using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

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

    // SHOP NOTES LOGIC
    public Button RightArrow;
    public Button LeftArrow;
    public GameObject[] NoteItems;
    public int itemIndex;

    // SHOP TITLES
    public TextMeshProUGUI NotesTitle;
    public TextMeshProUGUI ParticlesTitle;
    public TextMeshProUGUI PianoBarTitle;
    public TextMeshProUGUI LightsTitle;

    // BACK BUTTONS
    public Button MainMenu_BackButton;
    public Button ShopMenu_BackButton;

    // SHOP LOGIC
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemPrice;
    public TextMeshProUGUI PurchaseButton;

    // PLAYER STATS
    public TextMeshProUGUI PlayerMoney;

    private void Start()
    {
        main_NotesShop.SetActive(false);
        main_ParticlesShop.SetActive(false);
        main_PianoBarShop.SetActive(false);
        main_LightsShop.SetActive(false);
        ShopMenu_BackButton.gameObject.SetActive(false);
        itemIndex = 0;
        NoteItems[itemIndex].gameObject.SetActive(true);
        PurchaseButtonTextLogic(NoteItems[itemIndex].GetComponent<Item>());
    }

    public void PurchaseButtonTextLogic(Item _item)
    {
        if (_item.isPurchased)
        {
            PurchaseButton.text = "Select";
        }
        else
        {
            PurchaseButton.text = "Purchase";
        }
    }

    public void LeftButtonClicked()
    {
        Debug.Log("Left Clicked");
        if (itemIndex == 0)
        {
            NoteItems[itemIndex].SetActive(false);
            itemIndex = NoteItems.Length - 1;
            NoteItems[itemIndex].SetActive(true);
            ItemName.text = NoteItems[itemIndex].GetComponent<Item>().item;
            ItemPrice.text = NoteItems[itemIndex].GetComponent<Item>().price.ToString();
            PurchaseButtonTextLogic(NoteItems[itemIndex].GetComponent<Item>());
            return;
        }

        NoteItems[itemIndex].SetActive(false);
        itemIndex -= 1;
        NoteItems[itemIndex].SetActive(true);
        ItemName.text = NoteItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = NoteItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(NoteItems[itemIndex].GetComponent<Item>());

    }

    public void RightButtonClicked()
    {
        Debug.Log("Right Clicked");
        if (itemIndex == NoteItems.Length - 1)
        {
            NoteItems[itemIndex].SetActive(false);
            itemIndex = 0;
            NoteItems[itemIndex].SetActive(true);
            ItemName.text = NoteItems[itemIndex].GetComponent<Item>().item;
            ItemPrice.text = NoteItems[itemIndex].GetComponent<Item>().price.ToString();
            PurchaseButtonTextLogic(NoteItems[itemIndex].GetComponent<Item>());
            return;
        }

        NoteItems[itemIndex].SetActive(false);
        itemIndex += 1;
        NoteItems[itemIndex].SetActive(true);
        ItemName.text = NoteItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = NoteItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(NoteItems[itemIndex].GetComponent<Item>());
    }


    public void ShopMenuBackButtonClicked()
    {
        if (NotesButton_isCurrent)
        {
            NotesShopButtonClicked();
        }else if (ParticlesButton_isCurrent)
        {
            ParticlesShopButtonClicked();
        }else if (PianoBarButton_isCurrent)
        {
            PianoBarButtonClicked();
        }
        else if(LightsButton_isCurrent)
        {
            LightsButtonClicked();
        }
        else
        {
            Debug.Log("Error in the shop menu back button logic.");
        }

        ShopMenu_BackButton.gameObject.SetActive(false);
        MainMenu_BackButton.gameObject.SetActive(true);
    }

    public void PurchaseButtonClicked()
    {
        if (NoteItems[itemIndex].GetComponent<Item>().price < PersistentData.data.money)
        {
            if (NoteItems[itemIndex].GetComponent<Item>().isPurchased == false)
            {
                PersistentData.data.money -= NoteItems[itemIndex].GetComponent<Item>().price;
                NoteItems[itemIndex].GetComponent<Item>().isPurchased = true;
                PersistentData.SaveJsonData(PersistentData.data);

                // Update UI
                PlayerMoney.text = PersistentData.data.money.ToString();
                PurchaseButton.text = "Select";
            }
            else
            {
                Debug.Log("Selecting " + NoteItems[itemIndex].GetComponent<Item>().item);
            }
            
        }
        else
        {
            Debug.Log("Insufficient Funds");
        }
    }


    public void NotesShopButtonClicked()
    {
        if (NotesButton_isCurrent)
        {
            NotesTitle.gameObject.LeanMoveLocal(new Vector3(-1000, 400,0),1).setEaseOutSine();
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            NotesButton_isCurrent = false;
        }
        else
        {
            NotesTitle.gameObject.LeanMoveLocal(new Vector3(-300, 400, 0), 1).setEaseOutSine();
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(0, -800, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(true);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            NotesButton_isCurrent = true;
        }

        ShopMenu_BackButton.gameObject.SetActive(true);
        MainMenu_BackButton.gameObject.SetActive(false);
        
    }

    public void ParticlesShopButtonClicked()
    {
        if (ParticlesButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            ParticlesButton_isCurrent = false;
        }
        else{
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(0, -800, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(true);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            ParticlesButton_isCurrent = true;
        }

        ShopMenu_BackButton.gameObject.SetActive(true);
        MainMenu_BackButton.gameObject.SetActive(false);

    }

    public void PianoBarButtonClicked()
    {
        if (PianoBarButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(false);

            PianoBarButton_isCurrent = false;
        }
        else
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-1200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(0, -800, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(1200, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(true);
            main_LightsShop.SetActive(false);

            PianoBarButton_isCurrent = true;
        }

        ShopMenu_BackButton.gameObject.SetActive(true);
        MainMenu_BackButton.gameObject.SetActive(false);
    }

    public void LightsButtonClicked()
    {
        if (LightsButton_isCurrent)
        {
            main_NotesButton.gameObject.LeanMoveLocal(new Vector3(-600, 0, 0), 1).setEaseOutSine();
            main_ParticlesButton.gameObject.LeanMoveLocal(new Vector3(-200, 0, 0), 1).setEaseOutSine();
            main_PianoBarButton.gameObject.LeanMoveLocal(new Vector3(200, 0, 0), 1).setEaseOutSine();
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(600, 0, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
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
            main_LightsButton.gameObject.LeanMoveLocal(new Vector3(0, -800, 0), 1).setEaseOutSine();
            main_NotesShop.SetActive(false);
            main_ParticlesShop.SetActive(false);
            main_PianoBarShop.SetActive(false);
            main_LightsShop.SetActive(true);

            LightsButton_isCurrent = true;
        }

        ShopMenu_BackButton.gameObject.SetActive(true);
        MainMenu_BackButton.gameObject.SetActive(false);
    }


    
}
