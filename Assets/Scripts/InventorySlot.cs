using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Image _Image;
    private Item item;
    private string itemName = null;
    private string itemDescription = null;
    private Sprite itemSprite;
    private int itemQuantity = 0;
    public void SetItem(Item newItem)
    {
        item = newItem;
        itemName = item.GetItemName();
        itemDescription = item.GetItemDesc();
        itemSprite = item.GetSprite();
        _Image.sprite = itemSprite;

    }
    public void SetQuantity(int quantity)
    {
        itemQuantity = quantity;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public int GetQuantity()
    {
        return itemQuantity;
    }
    void Start()
    {
        GameObject image;
        image = this.gameObject.transform.GetChild(0).gameObject;
        _Image = image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
