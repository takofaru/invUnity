using Unity.VisualScripting;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, IInteract
{
    [SerializeField]
    private GameObject inventoryMenu;
    private InventoryManager _InventoryManager;
    private SpriteRenderer _SpriteRenderer;
    [SerializeField]
    private Item item;
    private Sprite itemSprite;
    private string itemName;
    private string itemDescription;
    private int itemMaxQuantity;
    public Item GetItem()
    {
        return item;
    }
    public int GetItemMaxQuantity()
    {
        return itemMaxQuantity;
    }
    public string GetItemName()
    {
        return itemName;
    }
    public void Initialization(Item itemInit)
    {
        item = itemInit;
        itemSprite = item.GetSprite();
        itemName = item.GetItemName();
        itemDescription = item.GetItemDesc();
        itemMaxQuantity = item.GetMaxQuantity();
        _SpriteRenderer.sprite = itemSprite;
    }
    void IInteract.Interact()
    {
        _InventoryManager.AddItem(this.gameObject);
    }
    void Start()
    {
        _InventoryManager = inventoryMenu.GetComponent<InventoryManager>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        Initialization(item);
    }
}
