using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private ItemDictionary itemDictionary;

    public GameObject inventoryPanel; 
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;
    
    // Start is called once before the first frame update
    void Start()
    {

        itemDictionary = FindObjectOfType<ItemDictionary>();

        //for (int i = 0; i < slotCount; i++)
        //{
        //    Slot slot = Instantiate(slotPrefab, inventorypanel.transform).GetComponent<Slot>();
        //    if (i < itemPrefabs.Length)
        //    {
        //        GameObject item = Instantiate(itemPrefabs[i], slot.transform);
        //        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //        slot.currentIteam = item;   
        //    }
        //}
    }

    public List<InventorySaveData> GetInventoryItem()
    {
        List<InventorySaveData> invData = List<InventorySaveData>();
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.currentIteam != null)
            {
                item item = slot.currentIteam.GetComponent<item>();
                invData.Add(new InventorySaveData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
        }
        return invData;
    }

    private List<T> List<T>()
    {
        throw new System.NotImplementedException();
    }

    public void SetInventoryItem(List<InventorySaveData> inventorySaveData)
    {
        //Clear inventory panel - avoid duplicates 
        foreach(Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        //Create new slots 
        for(int i = 0 ; i < slotCount ; i++)
        {
            Instantiate(slotPrefab, inventoryPanel.transform);
        }

        //Populate slots with saved items 
        foreach(InventorySaveData data in inventorySaveData)
        {
            if(data.slotIndex < slotCount)
            {
                Slot slot = inventoryPanel.transform.GetChild(data.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.itemID);
                if (itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentIteam = item;
                }
            }
        }
    }

    public bool AddItem(GameObject itemPrefab)
    {
        //Look for empty slot
        foreach(Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>(); 
            if (slot != null && slot.currentIteam ==null)
            {
                GameObject newItem = Instantiate(itemPrefab, slot.transform);
                newItem.GetComponent<RectTransform>().anchoredPosition= Vector2.zero;
                slot.currentIteam = newItem;
                return true;    
            }
        }

        Debug.Log("Inventory is full!");
        return false;
    }
}
