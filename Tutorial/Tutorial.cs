using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject MenuCanvasUI;
    public GameObject TutorialCanvasUI;

    void Awake()
    {
        TutorialCanvasUI.SetActive(true);
        MenuCanvasUI.SetActive(false);
        UICanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TutorialCanvasUI.SetActive(false);
            MenuCanvasUI.SetActive(false);
            UICanvas.SetActive(true);
        }
    }
}