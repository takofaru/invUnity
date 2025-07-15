using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField]
    private Item item;
    private string itemName;
    private string itemDesc;
    private SpriteRenderer _sr;

    public void InitializeItem(Item itemInit)
    {
        itemInit = item;
        itemName = itemInit.GetItemName();
        itemDesc = itemInit.GetItemDesc();
        _sr.sprite = itemInit.GetSprite();

    }
    public Item GetItem()
    {
        return item;
    }
    public string GetItemName()
    {
        return item.GetItemName();
    }
    public int GetMaxQuantity()
    {
        return item.GetMaxQuantity();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        InitializeItem(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
