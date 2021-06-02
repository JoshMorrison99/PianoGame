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
    private int listOffset = 23;

    // PLAYER STATS
    public TextMeshProUGUI PlayerMoney;

    public TextMeshProUGUI InsufficientFundsText;

    public int itemIndex;

    private void Start()
    {
        LoadNoteItems();
        itemIndex = 0;
        KeyItems[itemIndex].gameObject.SetActive(true);
        PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());
    }

    public void LoadNoteItems()
    {
        GameObject NotesRootHolder = GameObject.Find("KeysHolder");

        int counter = 0;
        foreach (Transform item in NotesRootHolder.transform)
        {
            KeyItems[counter] = item.gameObject;
            counter += 1;
        }
    }

    public void ClearCurrentlySelectedItem()
    {
        foreach (var item in KeyItems)
        {
            item.GetComponent<Item>().isCurrentlySelected = false;
        }
    }

    public void SetCurrentlySelectedItem()
    {
        foreach (var item in KeyItems)
        {
            if (item.GetComponent<Item>().isCurrentlySelected)
            {
                PersistentData.data.currentKeyItem = KeyItems[itemIndex].GetComponent<KeyItem>().color;
            }
        }
    }

    public void PurchaseButtonClicked()
    {
        Debug.Log("List Index: " + KeyItems[itemIndex]);
        Debug.Log("Persistent Index: " + PersistentData.data._ItemList[itemIndex + listOffset]);
        if (KeyItems[itemIndex].GetComponent<Item>().price <= PersistentData.data.money || KeyItems[itemIndex].GetComponent<Item>().isPurchased)
        {
            if (KeyItems[itemIndex].GetComponent<Item>().isPurchased == false)
            {
                PersistentData.data.money -= KeyItems[itemIndex].GetComponent<Item>().price;
                KeyItems[itemIndex].GetComponent<Item>().isPurchased = true;
                ClearCurrentlySelectedItem();
                KeyItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;

                PersistentData.data._ItemList[itemIndex + listOffset].isPurchased = true;
                PersistentData.data._ItemList[itemIndex + listOffset].isCurrentlySelected = true;

                PersistentData.data.currentKeyItem = KeyItems[itemIndex].GetComponent<KeyItem>().color;
                PersistentData.SaveJsonData(PersistentData.data);

                // Update UI
                PlayerMoney.text = PersistentData.data.money.ToString();
                PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());

                StartCoroutine(ShopTextAnimation("Purchase Complete"));

            }
            else
            {
                Debug.Log("Selecting " + KeyItems[itemIndex].GetComponent<Item>().item);
                ClearCurrentlySelectedItem();
                KeyItems[itemIndex].GetComponent<Item>().isCurrentlySelected = true;

                PersistentData.data._ItemList[itemIndex + listOffset].isCurrentlySelected = true;

                PersistentData.data.currentKeyItem = KeyItems[itemIndex].GetComponent<KeyItem>().color;
                PurchaseButtonTextLogic(KeyItems[itemIndex].GetComponent<Item>());
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
