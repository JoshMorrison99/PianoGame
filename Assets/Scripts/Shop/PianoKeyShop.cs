using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PianoKeyShop : MonoBehaviour
{

    // SHOP PIANO BAR LOGIC
    public GameObject[] KeyItems;
    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemPrice;
    public TextMeshProUGUI PurchaseButton;

    // PLAYER STATS
    public TextMeshProUGUI PlayerMoney;

    public int itemIndex;

    private void Start()
    {
        itemIndex = 0;
        KeyItems[itemIndex].gameObject.SetActive(true);
        SetCurrentlySelectedItem();
    }

    public void SetCurrentlySelectedItem()
    {
        foreach (var item in KeyItems)
        {
            PurchaseButtonTextLogic(item.GetComponent<Item>());
        }
    }

    public void ClearCurrentlySelectedItem()
    {
        foreach (var item in KeyItems)
        {
            item.GetComponent<Item>().isCurrentlySelected = false;
        }
    }

    public void PurchaseButtonClicked()
    {
        if (KeyItems[itemIndex].GetComponent<Item>().price < PersistentData.data.money)
        {
            if (KeyItems[itemIndex].GetComponent<Item>().isPurchased == false)
            {
                PersistentData.data.money -= KeyItems[itemIndex].GetComponent<Item>().price;
                KeyItems[itemIndex].GetComponent<Item>().isPurchased = true;
                ClearCurrentlySelectedItem();
                KeyItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;

                PersistentData.data._ItemList[itemIndex].isPurchased = true;
                PersistentData.data._ItemList[itemIndex].isCurrentlySelected = true;

                PersistentData.data.currentKeyItem = KeyItems[itemIndex].GetComponent<KeyItem>().color;
                PersistentData.SaveJsonData(PersistentData.data);

                // Update UI
                PlayerMoney.text = PersistentData.data.money.ToString();
                PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());


            }
            else
            {
                Debug.Log("Selecting " + KeyItems[itemIndex].GetComponent<Item>().item);
                ClearCurrentlySelectedItem();
                KeyItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;

                PersistentData.data._ItemList[itemIndex].isCurrentlySelected = true;

                PersistentData.data.currentKeyItem = KeyItems[itemIndex].GetComponent<KeyItem>().color;
                PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());
                PersistentData.SaveJsonData(PersistentData.data);
            }

        }
        else
        {
            Debug.Log("Insufficient Funds");
        }
    }

    public void LeftPianoKeyButtonClicked()
    {
        if (itemIndex == 0)
        {
            KeyItems[itemIndex].SetActive(false);
            itemIndex = KeyItems.Length - 1;
            KeyItems[itemIndex].SetActive(true);
            ItemName.text = KeyItems[itemIndex].GetComponent<Item>().item;
            ItemPrice.text = KeyItems[itemIndex].GetComponent<Item>().price.ToString();
            PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());
            return;
        }

        KeyItems[itemIndex].SetActive(false);
        itemIndex -= 1;
        KeyItems[itemIndex].SetActive(true);
        ItemName.text = KeyItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = KeyItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());

    }

    public void RightPianoKeyButtonClicked()
    {
        if (itemIndex == KeyItems.Length - 1)
        {
            KeyItems[itemIndex].SetActive(false);
            itemIndex = 0;
            KeyItems[itemIndex].SetActive(true);
            ItemName.text = KeyItems[itemIndex].GetComponent<Item>().item;
            ItemPrice.text = KeyItems[itemIndex].GetComponent<Item>().price.ToString();
            PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());
            return;
        }

        KeyItems[itemIndex].SetActive(false);
        itemIndex += 1;
        KeyItems[itemIndex].SetActive(true);
        ItemName.text = KeyItems[itemIndex].GetComponent<Item>().item;
        ItemPrice.text = KeyItems[itemIndex].GetComponent<Item>().price.ToString();
        PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());
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
