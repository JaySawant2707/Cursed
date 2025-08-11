using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    const string PLAYER_STRING = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_STRING))
        {
            SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
