using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ISaveable
{

    public int id;
    public string item;
    public int price;
    public bool isPurchased;
    public bool isCurrentlySelected;
    public string itemType;

    public void LoadFromSaveData(PersistentDataInformation a_SaveData)
    {
        foreach (PersistentDataInformation.ItemData myItemData in a_SaveData.m_ItemList)
        {
            Debug.Log("ID: " + myItemData.m_id + " is Purchased? " + myItemData.m_isPurchased);
            id = myItemData.m_id;
            item = myItemData.m_itemName;
            price = myItemData.m_price;
            isPurchased = myItemData.m_isPurchased;
            isCurrentlySelected = myItemData.m_isCurrentlySelected;
            itemType = myItemData.m_itemType;
            break;
            
        }

    }

    public void PopulateSaveData(PersistentDataInformation a_SaveData)
    {
        PersistentDataInformation.ItemData myItemData = new PersistentDataInformation.ItemData();
        
        myItemData.m_id = id;
        myItemData.m_itemName = item;
        myItemData.m_price = price;
        myItemData.m_isPurchased = isPurchased;
        myItemData.m_isCurrentlySelected = isCurrentlySelected;
        myItemData.m_itemType = itemType;

        Debug.Log("ID: " + myItemData.m_id + " is Purchased? " + myItemData.m_isPurchased);

        a_SaveData.m_ItemList.Add(myItemData);
    }
}
