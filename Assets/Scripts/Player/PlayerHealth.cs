using Invector.vCharacterController;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] GameObject model;

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

        deathParticles.Play();

        GetComponent<vThirdPersonInput>().enabled = false;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Animator>().enabled = false;
        model.SetActive(false);

        if (reloadSceneOnDeath)
        {
            Invoke("ReloadScene", deathDelay);
        }
        else
        {
            ResetHealth();
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
