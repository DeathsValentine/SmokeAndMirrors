using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemlist;

    // Initialize an Inventory
    public Inventory()
    {
        itemlist = new List<Item>();
        addItem(new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        Debug.Log(itemlist.Count);
    }

    //Adds an item to the inventory
    public void addItem(Item item)
    {
        itemlist.Add(item);
    }
}
