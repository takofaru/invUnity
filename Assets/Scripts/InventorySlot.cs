using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [HideInInspector]
    public Image itemImage;
    [HideInInspector]
    public Item item;
    [HideInInspector]
    public string itemName = null;
    [HideInInspector]
    public string itemDescription = null;
    [HideInInspector]
    public int itemQuantity = 0;
   
    void Start()
    {
        GameObject image;

        image = this.gameObject.transform.GetChild(0).gameObject;

        itemImage = image.GetComponent<Image>();
    }
}
