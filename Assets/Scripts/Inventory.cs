using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemData> items = new List<ItemData>();

    public void LogInventory()
    {
        foreach (ItemData itemData in items)
        {
            Debug.Log(itemData.ToString());
        }
    }

    public List<ItemData> GetItems()
    {
        return items;
    }

    public void AddItem(ItemData itemData)
    {
        items.Add(itemData);
        LogInventory();
    }
}
