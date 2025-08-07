using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] int damage = 1;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
