using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage;
    public Item item;
    public string itemName = null;
    public string itemDescription = null;
    public int itemQuantity = 0;
   
    void Start()
    {
        GameObject image;

        image = this.gameObject.transform.GetChild(0).gameObject;

        itemImage = image.GetComponent<Image>();
    }
}
