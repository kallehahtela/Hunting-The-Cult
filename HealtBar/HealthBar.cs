using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Text healthCounter;
    public GameObject PlayerState;

    private float currentHealt;
    private float maxHealth;


    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        currentHealt = PlayerState.GetComponent<PlayerState>().currentHealth;
        maxHealth = PlayerState.GetComponent<PlayerState>().maxHealth;

        float fillValue = currentHealt / maxHealth; // 0 - 1
        slider.value = fillValue;

        healthCounter.text = currentHealt + "/" + maxHealth;
    }
}
