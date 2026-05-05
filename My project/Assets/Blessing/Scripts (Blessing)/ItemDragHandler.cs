using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler  
{
    Transform originalParent;
    CanvasGroup canvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; //Save OG parent 
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; //semi-transparent during drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; //Follow the mouse 
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       canvasGroup.blocksRaycasts = true; //Enable raycats
        canvasGroup.alpha = 1f; //No longer transparent 

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); //Slot where item dropped
        Slot originalSlot = originalParent.GetComponent<Slot>();    
        
        if (dropSlot != null)
        {
            //Is a slot under drag point 
            if (dropSlot.currentIteam != null)
            {
                //Slot has an item - swap items 
                dropSlot.currentIteam.transform.SetParent(originalSlot.transform);
                originalSlot.currentIteam = dropSlot.currentIteam;
                dropSlot.currentIteam.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                originalSlot.currentIteam = null;
            }

            //Move item into drop slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentIteam = gameObject;
        }
        else
        {
            //No slot under drop point
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //Center
    }
}
