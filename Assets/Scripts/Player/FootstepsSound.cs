using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCrystalSound()
    {
        audioSource.Play();
    }
}
