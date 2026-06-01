using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public bool IsMenuOpen { get; private set; }

    void Start()
    {
        if (menuCanvas == null)
        {
            Debug.LogError("MenuController: menuCanvas is not assigned.", this);
            return;
        }

        menuCanvas.SetActive(false);
        IsMenuOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    // Called from code (Tab) or from a UI Button OnClick
    public void ToggleMenu()
    {
        if (menuCanvas == null) return;

        bool newState = !menuCanvas.activeSelf;
        menuCanvas.SetActive(newState);
        IsMenuOpen = newState;
        Debug.Log("Menu toggled -> " + newState, this);
    }

    // Optional helpers for direct wiring
    public void OpenMenu()
    {
        if (menuCanvas == null) return;
        menuCanvas.SetActive(true);
        IsMenuOpen = true;
    }

    public void CloseMenu()
    {
        if (menuCanvas == null) return;
        menuCanvas.SetActive(false);
        IsMenuOpen = false;
    }
}
