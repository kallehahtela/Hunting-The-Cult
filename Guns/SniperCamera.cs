using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SniperCamera : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject scopeCam;
    public GameObject sniperScope;
    public Image crosshair;
    public TextMeshProUGUI FPSText;

    private bool isSwitchingToPlayerCam = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            scopeCam.SetActive(true);
            playerCam.SetActive(false);
            crosshair.enabled = false;
            sniperScope.SetActive(true);
            FPSText.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            SwitchToPlayerCamera();
        }
    }

    public void SwitchToPlayerCamera()
    {
        if (!isSwitchingToPlayerCam)
        {
            isSwitchingToPlayerCam = true;

            StartCoroutine(SwitchToPlayerCameraAfterDelay());
        }
    }

    IEnumerator SwitchToPlayerCameraAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);

        scopeCam.SetActive(false);
        playerCam.SetActive(true);
        crosshair.enabled = true;
        sniperScope.SetActive(false);
        FPSText.gameObject.SetActive(true);

        isSwitchingToPlayerCam = false;
    }
}