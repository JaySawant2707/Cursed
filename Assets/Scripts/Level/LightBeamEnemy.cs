 using UnityEngine;

public class LightBeamEnemy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PetrifyPlayer(other.gameObject);
        }
    }

    void PetrifyPlayer(GameObject player)
    {
        Invector.vCharacterController.vThirdPersonInput sc = player.GetComponent<Invector.vCharacterController.vThirdPersonInput>();
        Animator am = player.GetComponent<Animator>();
        Rigidbody rb = player.GetComponent<Rigidbody>();
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (sc != null && am != null && rb != null && ph != null)
        {
            sc.enabled = false;
            am.enabled = false;
            rb.linearVelocity = Vector3.zero;
            ph.Die();
        }
    }
}
