using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    public void Init(Vector3 direction, float speed, float lifetime)
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(999);
            Destroy(this.gameObject);
        }
    }
}
