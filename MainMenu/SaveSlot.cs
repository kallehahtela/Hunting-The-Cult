using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;

    public int slotNumber;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonText = transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        button.onClick.AddListener(() => 
        {
            if (SaveManager.Instance.isSlotEmpty(slotNumber))
            {
                SaveManager.Instance.SaveGame(slotNumber);
                DateTime dt = DateTime.Now;
                string time = dt.ToString("yyyy-MM-dd HH:mm");

                string description = "Saved Game " + slotNumber + " | " + time;

                buttonText.text = description;
                PlayerPrefs.SetString("Slot " + slotNumber + "Description", description);

                SaveManager.Instance.DeselectButton();
            }
            else
            {
                // DisplayOverrideWarning
            }

        }
        );
    }

    private void Update()
    {
        if (SaveManager.Instance.isSlotEmpty(slotNumber))
        {
            buttonText.text = "Empty";
        }
        else
        {
            buttonText.text = PlayerPrefs.GetString("Slot " + slotNumber + "Description");
        }
    }
}
