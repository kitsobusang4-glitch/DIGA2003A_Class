using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class PharmacyMechanics : MonoBehaviour
{
    [Header("Reference")]
    public GameObject bottle;    // Drag your bottle object here
    public GameObject randIcon; // Drag your R / money UI here

    [Header("State")]
    public bool dialogueFinished = false;
    private bool itemCollected = false;

    // Simple inventory flag
    public static bool hasMedicine = false;

    private void Start()
    {
        // Hide money icon at start
        if (randIcon != null)
        {
            randIcon.SetActive(false);
        }
    }

    void Update()
    {
        // When dialogue finishes and item not yet collected 
        if (dialogueFinished && !itemCollected)
        {
            CollectItem();
        }
    }
    public void DialogueEnded()
    {
        // This will be called from your dialogue script
        Debug.Log("Dialogue ended triggered!");
        dialogueFinished = true;
    }

    void CollectItem()
    {
        if (bottle == null) return;

        itemCollected = true;

        // Add to inventory 
        hasMedicine = true;

        Debug.Log("Dialogue ended triggered!");

        // Start transaction sequence 
        StartCoroutine(HandleTransaction());
    }

    IEnumerator HandleTransaction()
    {
        Debug.Log("Dialogue ended triggered!");

        // Show money
        if (randIcon != null)
        {
            randIcon.SetActive (true);
        }

        yield return new WaitForSeconds(2.0f);

        // Hide money
        if (randIcon != null)
        {
            randIcon.SetActive (false);
        }

        // Remove bottle 
        if (bottle != null)
        {
            bottle.SetActive(false);
            bottle = null;
        }

        Debug.Log("Dialogue ended triggered!");
    }
}
           
        
    





