using UnityEngine;
public class Portal : MonoBehaviour
{
    const string PLAYER_STRING = "Player";

    [SerializeField] int SceneIndexToLoad;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_STRING))
        {
            SceneLoader.Instance.LoadScene(SceneIndexToLoad);
        }
    }
}
