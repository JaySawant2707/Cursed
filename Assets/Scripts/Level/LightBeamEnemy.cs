 using UnityEngine;

public class LightBeamEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invector.vCharacterController.vThirdPersonInput sc = other.gameObject.GetComponent<Invector.vCharacterController.vThirdPersonInput>();
            Animator am = other.gameObject.GetComponent<Animator>();
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            PlayerHealth ph = other.gameObject.GetComponent<PlayerHealth>();
            if (sc != null && am != null && rb != null && ph != null)
            {
                sc.enabled = false;
                am.enabled = false;
                rb.linearVelocity = Vector3.zero;
                ph.Die();
            }
        }
    }
}
