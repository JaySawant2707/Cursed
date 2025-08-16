using UnityEngine;
public class Portal : MonoBehaviour
{
    const string PLAYER_STRING = "Player";

    [SerializeField] int SceneIndexToLoad;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_STRING))
        {
            FindFirstObjectByType<SceneLoader>().LoadScene(SceneIndexToLoad);
        }
    }
}
