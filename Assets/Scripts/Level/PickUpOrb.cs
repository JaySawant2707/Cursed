using System.Collections;
using TMPro;
using UnityEngine;

public class PickUpOrb : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textU;
    [SerializeField] GameObject orb;
    [SerializeField] GameObject portal;

    void Start()
    {
        portal.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(orb);
            portal.SetActive(true);
            StartCoroutine(Something());
        }
    }

    IEnumerator Something()
    {
        textU.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        textU.gameObject.SetActive(false);
    }
}
