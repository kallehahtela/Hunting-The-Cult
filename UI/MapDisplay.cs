using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Canvas uiCanvas;
    public Canvas mapCanvas;

    private bool isMapOpen = false;

    private void Start()
    {
        uiCanvas.enabled = !isMapOpen;
        mapCanvas.enabled = isMapOpen;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleCanvases();
        }
    }

    private void ToggleCanvases()
    {
        isMapOpen = !isMapOpen;

        uiCanvas.enabled = !isMapOpen;
        mapCanvas.enabled = isMapOpen;
    }
}
