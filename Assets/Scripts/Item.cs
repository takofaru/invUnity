using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private int maxQuantity;
    public string description;
    [System.Serializable]
    public enum itemType
    {
        consumable,
        material,
        normal
    }
    [SerializeField] private itemType type;
    public Sprite GetSprite()
    {
        return sprite;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public int GetMaxQuantity()
    {
        return maxQuantity;
    }
    public string GetItemDesc()
    {
        return description;
    }
}