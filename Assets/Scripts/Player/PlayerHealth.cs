using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [Header("Respawn Settings")]
    [SerializeField] private bool reloadSceneOnDeath = true;
    [SerializeField] private float deathDelay = 1f;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        Debug.Log("Player Take damage : " + damage + "\nHealth : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        Debug.Log("Player died!");

        // trigger animation, effects, sound

        if (reloadSceneOnDeath)
        {
            Invoke("ReloadScene", deathDelay);
        }
        else
        {
            ResetHealth();
            // respawn logic
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
    }
}
