using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    [HideInInspector]
    public string itemName;
    [HideInInspector]
    public Sprite itemSprite;
    [HideInInspector]
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