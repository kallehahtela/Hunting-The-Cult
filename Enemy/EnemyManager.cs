using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public Image enemyImage; // Image component to display the enemy
    public TextMeshProUGUI enemyCountText; // TextMeshProUGUI component to display the enemy count

    private int enemyCount = 0; // Counter for the enemies

    // Method to increment the enemy count
    public void IncrementEnemyCount()
    {
        enemyCount++;
        UpdateEnemyCountText();
    }

    // Method to decrement the enemy count
    public void DecrementEnemyCount()
    {
        enemyCount--;
        UpdateEnemyCountText();
    }

    // Method to update the enemy count text
    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemies Alive: " + enemyCount.ToString();
    }

    // Method to check if any objects tagged as "Enemy" have been deleted
    public void CheckDeletedEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null)
            {
                Debug.Log("An object tagged as 'Enemy' has been deleted.");
                DecrementEnemyCount(); // Decrease the count if an enemy has been deleted
            }
        }
    }

    // Method to display the enemy image
    private void Start()
    {
        enemyImage.enabled = false;
    }

    private void Update()
    {
        if (enemyCount > 0)
        {
            enemyImage.enabled = true;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
            //enemyImage.enabled = false;
        }
    }
}