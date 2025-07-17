using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject[] inventorySlots;
    InventorySlot _InventorySlot;
    [SerializeField]
    private GameObject bag;
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
    public void AddItem(GameObject collectedItem)
    {
        CollectibleItem _CollectibleItem = collectedItem.GetComponent<CollectibleItem>();

        Debug.Log(_CollectibleItem.itemName);

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            Debug.Log(inventorySlots[i]);

            InventorySlot _InventorySlot = inventorySlots[i].GetComponent<InventorySlot>();
            Debug.Log(_InventorySlot.itemName);

            if (_CollectibleItem.itemName == _InventorySlot.itemName || _InventorySlot.itemName == "")
            {
                Debug.Log("Slot " + i + " is available");

                if (_CollectibleItem.itemMaxQuantity > _InventorySlot.itemQuantity)
                {
                    Debug.Log("Slot " + i + " is not in maximum amount");

                    SpawnItem(_InventorySlot, _CollectibleItem, collectedItem);
                    break;
                }
            }
        }
    }
    public void SpawnItem(InventorySlot _InventorySlot, CollectibleItem _CollectibleItem, GameObject collectedItem)
    {
        _InventorySlot.item = _CollectibleItem.item;
        _InventorySlot.itemName = _CollectibleItem.itemName;
        _InventorySlot.itemDescription = _CollectibleItem.itemDescription;
        _InventorySlot.itemImage.sprite = _CollectibleItem.itemSprite;
        _InventorySlot.itemQuantity += 1;

        Destroy(collectedItem);

        Debug.Log("Quantity: " + _InventorySlot.itemQuantity + ", Item Name = " + _InventorySlot.itemName);
    }
}
