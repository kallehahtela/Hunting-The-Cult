using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 50f;
    public float range = 1000f;
    public float reloadTime = 1.5f;
    public int maxAmmoPerMag = 100;

    public Camera scopeCam;
    public Camera playerCam;
    public AudioSource sniperShot;
    public AudioSource reloadSound;
    public TextMeshProUGUI ammoText;

    private bool canShoot = true;
    private bool isReloading = false;
    private int currentAmmo;

    private void Start()
    {
        currentAmmo = maxAmmoPerMag;
        UpdateAmmoText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && playerCam.gameObject.activeSelf)
        {
            if (currentAmmo < maxAmmoPerMag)
            {
                StartCoroutine(Reload());
                reloadSound.Play();
            }
        }

        if (canShoot && Input.GetMouseButtonDown(0) && scopeCam.gameObject.activeSelf)
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                StartCoroutine(Reload());
                reloadSound.Play();
            }
        }
    }

    void Shoot()
    {
        sniperShot.Play();
        canShoot = false;
        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(scopeCam.transform.position, scopeCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        // Switch to player camera immediately after the shot
        scopeCam.gameObject.SetActive(false);
        playerCam.gameObject.SetActive(true);

        // Switch back to scope camera after a delay
        StartCoroutine(SwitchToScopeCameraAfterDelay());

        UpdateAmmoText();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        int ammoToAdd = maxAmmoPerMag - currentAmmo;
        //currentAmmo = maxAmmoPerMag;
        canShoot = true;
        isReloading = false;
        Debug.Log("Reloaded");

        UpdateAmmoText();
    }

    IEnumerator SwitchToScopeCameraAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);

        if (playerCam.gameObject.activeSelf)
        {
            scopeCam.gameObject.SetActive(true);
            playerCam.gameObject.SetActive(false);
        }
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + currentAmmo;
    }
}