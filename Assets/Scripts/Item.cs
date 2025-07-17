using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int maxQuantity;
    public string itemDescription;
    [System.Serializable]
    public enum itemType
    {
        consumable,
        material,
        normal
    }
    public itemType type;
}