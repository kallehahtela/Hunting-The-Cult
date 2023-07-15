using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterVehicle : MonoBehaviour
{
    private bool inVehicle = false;
    CarControllerLite vehicleScript;
    PlayerMovement playerScript;
    public GameObject guiObj;
    GameObject player;
    public Camera playerCamera;
    public Camera CarCamera;

    void Start()
    {
        vehicleScript = GetComponent<CarControllerLite>();
        playerScript = GetComponent<PlayerMovement>();
        player = GameObject.FindWithTag("Player");
        guiObj.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && inVehicle == false)
        {
            guiObj.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                guiObj.SetActive(false);
                player.transform.parent = gameObject.transform;
                vehicleScript.enabled = true;
                playerScript.enabled = false;
                player.SetActive(false);
                inVehicle = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObj.SetActive(false);
        }
    }
    void Update()
    {
        if (inVehicle == true && Input.GetKey(KeyCode.F))
        {
            vehicleScript.enabled = false;
            playerScript.enabled = true;
            player.SetActive(true);
            player.transform.parent = null;
            inVehicle = false;

        }
    }
}
