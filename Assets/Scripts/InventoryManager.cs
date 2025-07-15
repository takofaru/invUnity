using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] inventorySlots;
    InventorySlot _InventorySlot;
    [SerializeField]
    private GameObject bag;
    bool isOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleInventory()
    {
        if (bag.activeSelf)
        {
            bag.SetActive(false);
        }
        else if (!bag.activeSelf)
        {
            bag.SetActive(true);
        }
    }
    public void AddItem(GameObject item)
    {
        CollectibleItem _CollectibleItem = item.GetComponent<CollectibleItem>();
        Debug.Log(_CollectibleItem.GetItemName());
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            Debug.Log(inventorySlots[i]);
            InventorySlot _InventorySlot = inventorySlots[i].GetComponent<InventorySlot>();
            Debug.Log(_InventorySlot);
            if (_CollectibleItem.GetItemName() == _InventorySlot.GetItemName() || _InventorySlot.GetItemName() == null)
            {
                if (_CollectibleItem.GetItemMaxQuantity() > _InventorySlot.GetQuantity())
                {
                    int tempQuantity = _InventorySlot.GetQuantity() + 1;
                    _InventorySlot.SetItem(_CollectibleItem.GetItem());
                    _InventorySlot.SetQuantity(tempQuantity);
                    Destroy(item);
                    Debug.Log("I want your seed");
                    break;
                }
                else
                {
                    Debug.Log("Not Available");
                }
            }
        }
    }
}
