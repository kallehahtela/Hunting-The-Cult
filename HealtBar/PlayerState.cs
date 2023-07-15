using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; set; }

    // --- Player Health --- // 
    public float currentHealth;
    public float maxHealth;

    // --- Player Calories --- // 
    public float currentCalories;
    public float maxCalories;

    // --- Player Hydration --- // 
    public float currentHydrationPercent;
    public float maxHydrationPercent;

    public AudioSource hurtSound;
    public AudioSource heartbeatSound;

    float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

    public bool isHydrationActive;

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
        currentHealth = maxHealth;
        currentCalories = maxCalories;
        currentHydrationPercent = maxHydrationPercent;
    }

    void Update()
    {
        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        if (distanceTravelled >= 5)
        {
            distanceTravelled = 0;
            currentCalories -= 1;
        }

        if (currentCalories <= 0)
        {
            //StartCoroutine(DecreaseHealthIfCaloriesZero());
            currentCalories = 0;
        }

        if (currentHydrationPercent <= 0)
        {
            StartCoroutine(DecreaseHydration());
            currentHydrationPercent = 0;
        }
    }

    public void setHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

    public void setCalories(float newCalories)
    {
        currentCalories = newCalories;
    }

    public void setHydration(float newHydration)
    {
        currentHydrationPercent = newHydration;
    }

    IEnumerator DecreaseHydration()
    {
        while (true)
        {
            // Decrease the hydration by 1% after every 2 seconds
            currentHydrationPercent -= 1;
            yield return new WaitForSeconds(2);

            while (currentHealth > 0)
            {
                if (currentHydrationPercent <= 0)
                {
                    currentHealth -= 10;
                    hurtSound.Play();

                    yield return new WaitForSeconds(3);
                }
                else
                {
                    yield return null;
                }
            }

            // Player's health is <= 0, activate the MainMenu scene
            SceneManager.LoadScene("MainMenu");
        }
    }

    /*IEnumerator DecreaseHealthIfCaloriesZero()
    {
        while (true)
        {
            // If the player has eaten enough, set the currentHealth to the right number and stop the hurt sound from playing
            if (currentCalories >= 1)
            {
                currentHealth = currentHealth;
                hurtSound.Stop();
            }
            // Reduce player's health when calories reach 0
            else if (currentCalories <= 0)
            {
                currentHealth -= 10;
                hurtSound.Play();
                yield return new WaitForSeconds(4);
                currentCalories = 0;

                if (currentCalories <= 0)
                {
                    SceneManager.LoadScene("StartingAnim");
                    yield break; // Exit the coroutine when calories reach 0
                }
            }

            yield return null; // Wait for the next frame
        }
    }*/
}