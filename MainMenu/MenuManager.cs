using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; set; }

    public GameObject MenuCanvas;
    public GameObject UICanvas;
    public GameObject OptionsScreen;
    public GameObject ControlsScreen;
    public GameObject menu;


    public bool isMenuOpen;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isMenuOpen)
        {
            OptionsScreen.SetActive(false);
            ControlsScreen.SetActive(false);
            menu.SetActive(true);

            UICanvas.SetActive(false);
            MenuCanvas.SetActive(true);
            isMenuOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SelectionManager.Instance.DisableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isMenuOpen)
        {
            UICanvas.SetActive(true);
            MenuCanvas.SetActive(false);
            isMenuOpen = false;

            if (CraftingSystem.Instance.isOpen == false && InventorySystem.Instance.isOpen == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
            }

            SelectionManager.Instance.EnableSelection();
            SelectionManager.Instance.GetComponent<SelectionManager>().enabled = true;
        }
    }

    public void OpenControls()
    {
        UICanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        isMenuOpen = false;

        OptionsScreen.SetActive(false);
        ControlsScreen.SetActive(true);
        menu.SetActive(false);
    }

    public void CloseControls()
    {
        UICanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        isMenuOpen = false;

        OptionsScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        menu.SetActive(true);
    }

    public void OpenOptions()
    {
        UICanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        isMenuOpen = false;

        OptionsScreen.SetActive(true);
        ControlsScreen.SetActive(false);
        menu.SetActive(false);
    }

    public void CloseOptions()
    {
        UICanvas.SetActive(false);
        MenuCanvas.SetActive(true);
        isMenuOpen = true;

        OptionsScreen.SetActive(false);
        ControlsScreen.SetActive(false);
        menu.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
