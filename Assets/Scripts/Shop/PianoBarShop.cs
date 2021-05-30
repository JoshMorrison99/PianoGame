using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PianoBarShop : MonoBehaviour
{
    // SHOP PIANO BAR LOGIC
    public GameObject[] PianoBarItems;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemPrice;
    public TextMeshProUGUI PurchaseButton;

    // PLAYER STATS
    public TextMeshProUGUI PlayerMoney;

    public int itemIndex;


    private void Start()
    {
        itemIndex = 0;
        PianoBarItems[itemIndex].gameObject.SetActive(true);
        SetCurrentlySelectedItem();
    }

    public void SetCurrentlySelectedItem()
    {
        foreach (var item in PianoBarItems)
        {
            PurchaseButtonTextLogic(item.GetComponent<Item>());
        }
    }

    public void ClearCurrentlySelectedItem()
    {
        foreach (var item in PianoBarItems)
        {
            item.GetComponent<Item>().isCurrentlySelected = false;
        }
    }

    public void PurchaseButtonClicked()
    {
        if (PianoBarItems[itemIndex].GetComponent<Item>().price < PersistentData.data.money)
        {
            if (PianoBarItems[itemIndex].GetComponent<Item>().isPurchased == false)
            {
                PersistentData.data.money -= PianoBarItems[itemIndex].GetComponent<Item>().price;
                PianoBarItems[itemIndex].GetComponent<Item>().isPurchased = true;
                ClearCurrentlySelectedItem();
                PianoBarItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;
                PersistentData.data.currentPianoBarItem = PianoBarItems[itemIndex].GetComponent<PianoBarItem>();
                PersistentData.SaveJsonData(PersistentData.data);

                // Update UI
                PlayerMoney.text = PersistentData.data.money.ToString();
                PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());


            }
            else
            {
                Debug.Log("Selecting " + PianoBarItems[itemIndex].GetComponent<Item>().item);
                ClearCurrentlySelectedItem();
                PianoBarItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;
                PersistentData.data.currentPianoBarItem = PianoBarItems[itemIndex].GetComponent<PianoBarItem>();
                PurchaseButtonTextLogic(PianoBarItems[itemIndex].GetComponent<Item>());
                PersistentData.SaveJsonData(PersistentData.data);
            }

        }
        else
        {
            Debug.Log("Insufficient Funds");
        }
    }

    public void LeftPianoBarButtonClicked()
    {
        Debug.Log("Left Clicked");
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
        Debug.Log("Right Clicked");
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
