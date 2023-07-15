using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    private EnemyManager enemyManager; // Reference to the enemy manager script
    public GameObject enemy;

    public AudioSource HitEnemy;
    
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.IncrementEnemyCount();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 50)
        {
            HitEnemy.Play();
        }

        if (health <= 0f)
        {
            HitEnemy.Play();
            Die();
        }
    }

    private void Die()
    {
        enemyManager.DecrementEnemyCount();
        enemyManager.CheckDeletedEnemies();
        Destroy(enemy);
    }
}
