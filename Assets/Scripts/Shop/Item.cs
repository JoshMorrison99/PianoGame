using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ISaveable
{
    public int id;
    public string item;
    public int price;
    public bool isPurchased;


    public void LoadFromSaveData(PersistentDataInformation a_SaveData)
    {
        foreach (PersistentDataInformation.ItemData myItemData in a_SaveData.m_ItemList)
        {
            if (myItemData.m_id == id)
            {
                id = myItemData.m_id;
                item = myItemData.m_itemName;
                price = myItemData.m_price;
                isPurchased = myItemData.m_isPurchased;
                break;
            }
        }

    }

    public void PopulateSaveData(PersistentDataInformation a_SaveData)
    {
        PersistentDataInformation.ItemData myItemData = new PersistentDataInformation.ItemData();
        myItemData.m_id = id;
        myItemData.m_itemName = item;
        myItemData.m_price = price;
        myItemData.m_isPurchased = isPurchased;

        a_SaveData.m_ItemList.Add(myItemData);
    }
}
