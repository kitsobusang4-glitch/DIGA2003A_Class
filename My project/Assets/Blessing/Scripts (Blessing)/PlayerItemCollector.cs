using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerItemCollector : MonoBehaviour
{
    private InventoryController inventoryController;
    // Start is called before the first frame update 
    void Start()
    {
        inventoryController = Object.FindAnyObjectByType<InventoryController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            Debug.Log("PLAYER ITEM COLLECTOR TRIGGERED");
            //rest of code...
        }
        if (collision.CompareTag("Item"))
            if (true)
        {
            item item = collision.GetComponent<item>();
            if (item != null)
            {
                //Add item inventory 
                bool itemAdded = inventoryController.AddItem(collision.gameObject);
                Debug.Log("AddItem return: " + itemAdded);
                if (itemAdded)
                {
                    Debug.Log("Destroying item");
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
