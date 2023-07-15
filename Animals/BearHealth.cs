using UnityEngine;

public class BearHealth : MonoBehaviour
{
    public float health = 50f;
    public GameObject bear;
    public GameObject meat;

    void Start()
    {
        bear.SetActive(true);
        meat.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(bear);
        meat.SetActive(true);
    }
}