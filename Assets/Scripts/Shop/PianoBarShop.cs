using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PianoBarShop : MonoBehaviour
{
    // SHOP PIANO BAR LOGIC
    public GameObject[] PianoBarItems;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemPrice;
    public TextMeshProUGUI PurchaseButton;

    public TextMeshProUGUI InsufficientFundsText;

    // PLAYER STATS
    public TextMeshProUGUI PlayerMoney;

    public int itemIndex;
    private int listOffset = 11;


    private void Start()
    {
        LoadNoteItems();
        itemIndex = 0;
        PianoBarItems[itemIndex].gameObject.SetActive(true);
        ItemName.text = PianoBarItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = PianoBarItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());
        Debug.Log("IS PURCHASED? " + PianoBarItems[itemIndex].GetComponent<Item>().isPurchased);
    }

    public void LoadNoteItems()
    {
        GameObject NotesRootHolder = GameObject.Find("PianoBarHolder");

        int counter = 0;
        foreach (Transform item in NotesRootHolder.transform)
        {
            PianoBarItems[counter] = item.gameObject;
            counter += 1;
        }
    }

    public void ClearCurrentlySelectedItem()
    {
        foreach (var item in PianoBarItems)
        {
            item.GetComponent<Item>().isCurrentlySelected = false;
        }
    }

    public void SetCurrentlySelectedItem()
    {
        foreach (var item in PianoBarItems)
        {
            if (item.GetComponent<Item>().isCurrentlySelected)
            {
                PersistentData.data.currentPianoBarItem = PianoBarItems[itemIndex].GetComponent<PianoBarItem>().video;
            }
        }
    }

    public void PurchaseButtonClicked()
    {
        Debug.Log("List Index: " + PianoBarItems[itemIndex]);
        Debug.Log("Persistent Index: " + PersistentData.data._ItemList[itemIndex + listOffset]);
        if (PianoBarItems[itemIndex].GetComponent<Item>().price <= PersistentData.data.money || PianoBarItems[itemIndex].GetComponent<Item>().isPurchased)
        {
            if (PianoBarItems[itemIndex].GetComponent<Item>().isPurchased == false)
            {
                PersistentData.data.money -= PianoBarItems[itemIndex].GetComponent<Item>().price;
                PianoBarItems[itemIndex].GetComponent<Item>().isPurchased = true;
                ClearCurrentlySelectedItem();
                PianoBarItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;

                PersistentData.data._ItemList[itemIndex + listOffset].isPurchased = true;
                PersistentData.data._ItemList[itemIndex + listOffset].isCurrentlySelected = true;

                PersistentData.data.currentPianoBarItem = PianoBarItems[itemIndex].GetComponent<PianoBarItem>().video;
                PersistentData.SaveJsonData(PersistentData.data);

                // Update UI
                PlayerMoney.text = PersistentData.data.money.ToString();
                PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());


                StartCoroutine(ShopTextAnimation("Purchase Complete"));

            }
            else
            {
                Debug.Log("Selecting " + PianoBarItems[itemIndex].GetComponent<Item>().item);
                ClearCurrentlySelectedItem();
                PianoBarItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;

                PersistentData.data._ItemList[itemIndex + listOffset].isCurrentlySelected = true;

                PersistentData.data.currentPianoBarItem = PianoBarItems[itemIndex].GetComponent<PianoBarItem>().video;
                PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());
                PersistentData.SaveJsonData(PersistentData.data);
            }

        }
        else
        {
            Debug.Log("Insufficient Funds");
            StartCoroutine(ShopTextAnimation("Insufficient Funds"));
        }
    }

    public IEnumerator ShopTextAnimation(string text)
    {
        if (text == "Insufficient Funds")
        {
            InsufficientFundsText.text = text;
            InsufficientFundsText.color = Color.red;
        }
        else if (text == "Purchase Complete")
        {
            InsufficientFundsText.text = text;
            InsufficientFundsText.color = Color.green;
        }
        InsufficientFundsText.gameObject.SetActive(true);
        InsufficientFundsText.gameObject.LeanMoveLocal(new Vector3(0, 460, 0), 1).setEaseOutSine();
        yield return new WaitForSeconds(2f);
        InsufficientFundsText.gameObject.LeanMoveLocal(new Vector3(0, 600, 0), 1);
        yield return null;
    }

    public void LeftPianoBarButtonClicked()
    {
        if (itemIndex == 0)
        {
            PianoBarItems[itemIndex].SetActive(false);
            itemIndex = PianoBarItems.Length - 1;
            PianoBarItems[itemIndex].SetActive(true);
            ItemName.text = PianoBarItems[itemIndex].GetComponent<Item>().item;
            ItemPrice.text = PianoBarItems[itemIndex].GetComponent<Item>().price.ToString();
            PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());
            return;
        }

        PianoBarItems[itemIndex].SetActive(false);
        itemIndex -= 1;
        PianoBarItems[itemIndex].SetActive(true);
        ItemName.text = PianoBarItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = PianoBarItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());

    }

    public void RightPianoBarButtonClicked()
    {
        if (itemIndex == PianoBarItems.Length - 1)
        {
            PianoBarItems[itemIndex].SetActive(false);
            itemIndex = 0;
            PianoBarItems[itemIndex].SetActive(true);
            ItemName.text = PianoBarItems[itemIndex].GetComponent<Item>().item;
            ItemPrice.text = PianoBarItems[itemIndex].GetComponent<Item>().price.ToString();
            PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());
            return;
        }

        PianoBarItems[itemIndex].SetActive(false);
        itemIndex += 1;
        PianoBarItems[itemIndex].SetActive(true);
        ItemName.text = PianoBarItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = PianoBarItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());
    }

    public void PurchaseButtonTextLogic(Item _item)
    {
        Debug.Log("Item " + _item.isPurchased);
        Debug.Log("Item " + _item.item);
        if (_item.isPurchased)
        {
            if (_item.isCurrentlySelected)
            {
                PurchaseButton.text = "Selected";
            }
            else
            {
                PurchaseButton.text = "Select";
            }

        }
        else
        {
            PurchaseButton.text = "Purchase";
        }
    }

}
