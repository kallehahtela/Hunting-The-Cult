using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f; // Maximum health of the target
    public Slider healthSlider; // Slider component to display the health
    public GameObject enemy;

    private float currentHealth; // Current health of the target
    private EnemyManager enemyManager; // Reference to the enemy manager script

    // Method to initialize the target's health
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.IncrementEnemyCount();
    }

    // Method to take damage and update the health
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    // Method to update the health UI components
    public void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
    }

    // Method to handle the target's destruction
    private void Die()
    {
        enemyManager.DecrementEnemyCount();
        enemyManager.CheckDeletedEnemies();
        Destroy(enemy);
    }
}