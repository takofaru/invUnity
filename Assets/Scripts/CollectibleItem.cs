using Unity.VisualScripting;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, IInteract
{
    [SerializeField]
    private GameObject inventoryMenu;
    private InventoryManager _InventoryManager;
    private SpriteRenderer _SpriteRenderer;
    public Item item;
    [HideInInspector]
    public Sprite itemSprite;
    [HideInInspector]
    public string itemName;
    [HideInInspector]
    public string itemDescription;
    [HideInInspector]
    public int itemMaxQuantity;
    public void Initialization(Item itemInit)
    {
        item = itemInit;
        itemSprite = item.itemSprite;
        itemName = item.itemName;
        itemDescription = item.itemDescription;
        itemMaxQuantity = item.maxQuantity;
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
