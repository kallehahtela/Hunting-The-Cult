using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager Instance { get; set; }

    public bool onTarget;

    public GameObject selectedObject;

    public GameObject interaction_Info_UI;
    Text interaction_text;

    public Image centerDotIcon;
    public Image handIcon;

    private void Start()
    {
        onTarget = false;

        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }

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

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();


            if (interactable && interactable.playerInRange)
            {
                onTarget = true;
                selectedObject = interactable.gameObject;
                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);

                if (interactable.CompareTag("pickable"))
                {
                    centerDotIcon.gameObject.SetActive(false);
                    handIcon.gameObject.SetActive(true);
                }
                else
                {
                    handIcon.gameObject.SetActive(false);
                    centerDotIcon.gameObject.SetActive(true);
                }

            }
            else // if there is a hit, but we without an Interactable Script
            {
                onTarget = false;
                interaction_Info_UI.SetActive(false);
                handIcon.gameObject.SetActive(false);
                centerDotIcon.gameObject.SetActive(true);
            }

        }
        else // if there is no hit at all
        {
            onTarget = false;
            interaction_Info_UI.SetActive(false);
            handIcon.gameObject.SetActive(false);
            centerDotIcon.gameObject.SetActive(true);
        }
    }

    public void DisableSelection()
    {
        handIcon.enabled = false;
        centerDotIcon.enabled = false;
        interaction_Info_UI.SetActive(false);

        selectedObject = null;
    }

    public void EnableSelection()
    {
        handIcon.enabled = true;
        centerDotIcon.enabled = true;
        interaction_Info_UI.SetActive(true);
    }
}
