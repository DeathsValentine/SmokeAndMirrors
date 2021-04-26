using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string id;

    [SerializeField]
    private string itemName;

    [SerializeField]
    private string description;

    [SerializeField]
    private int cost;

    [SerializeField]
    private Sprite icon;

    public string GetItemName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return description;
    }

    public int GetCost()
    {
        return cost;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public override string ToString()
    {
        return itemName + " " + description + " " + cost;
    }
}
