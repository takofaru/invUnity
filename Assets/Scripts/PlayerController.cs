using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _Rigidbody2D;
    [SerializeField]
    private GameObject InventoryMenu;
    InventoryManager _InventoryManager;
    CollectibleItem _CollectibleItem;
    IInteract _IInteractableItem;
    GameObject[] items;
    List<GameObject> touchedItems = new List<GameObject>();
    GameObject collectibleItem;
    public float speed = 8f;
    float horizontalMovement;
    float verticalSpeed;
    bool isGround;
    bool touchItem;
    String listTouched;

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        _InventoryManager = InventoryMenu.GetComponent<InventoryManager>();
        verticalSpeed = _Rigidbody2D.linearVelocityY;
        items = GameObject.FindGameObjectsWithTag("collectibleItem");
        foreach (GameObject item in items)
        {
            Physics2D.IgnoreCollision(item.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
            foreach (GameObject otherItem in items)
            {
                Physics2D.IgnoreCollision(item.gameObject.GetComponent<BoxCollider2D>(), otherItem.gameObject.GetComponent<BoxCollider2D>());
            }
            Debug.Log(item + " Applied");
        }
    }
    void Update()
    {
        _Rigidbody2D.linearVelocity = new Vector2(horizontalMovement * speed, _Rigidbody2D.linearVelocityY);
    }
    // void FixedUpdate()
    // {
    //     for (int i = 0; i < touchedItems.Count; i++)
    //     {
    //         ItemHandler item = touchedItems[i].GetComponent<ItemHandler>();
    //         if (touchedItems.FindIndex(obj => obj.GetComponent<ItemHandler>().GetItemName() == item.GetItemName()) < i)
    //         {
    //             listTouched += item.GetItemName() + i + " ";
    //         }
    //         else
    //         {
    //             listTouched += item.GetItemName() + " ";
    //         }
                
    //     }
    //     Debug.Log(listTouched);
    //     Debug.Log("List Restarted");
    //     listTouched = null;
    // }
    public void Move(InputAction.CallbackContext ctx)
    {
        horizontalMovement = ctx.ReadValue<Vector2>().x;
    }

    void debug()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectibleItem"))
        {
            _CollectibleItem = collision.gameObject.GetComponent<CollectibleItem>();
            _IInteractableItem = collision.gameObject.GetComponent<IInteract>();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(_CollectibleItem.GetItemName());
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collectibleItem"))
        {
            _CollectibleItem = null;
            _IInteractableItem = null;
        }
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGround)
        {
            _Rigidbody2D.linearVelocityY = 10f;
            isGround = false;
        }
    }

    public void Inventory(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _InventoryManager.ToggleInventory();
            Debug.Log("Inventory");
        }
    }
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && _IInteractableItem != null)
        {
            Debug.Log("Interact Item");
            _IInteractableItem.Interact();
            // _inventoryManager.AddItem(touchedItems[touchedItems.Count - 1]);
            // Debug.Log("Object: " + itemObject.GetComponent<ItemHandler>().GetItemName());
            // Debug.Log("Test");
            // _inventoryManager.AddItem(itemObject);
            // Collider2D[] collision;
            // collision = Physics2D.OverlapCircleAll(transform.position, 2f);

        }
    }
}
