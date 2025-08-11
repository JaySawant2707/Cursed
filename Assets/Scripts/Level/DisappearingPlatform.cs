using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    [SerializeField] float appearIntervalTime;
    [SerializeField] bool appearOnStart = true;

    bool isVisible;
    float timer;
    Collider myCollider;
    MeshRenderer meshRenderer;

    void Start()
    {
        myCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        isVisible = appearOnStart;
        ToggleOnOff(appearOnStart);

    }

    void Update()
    {
        CountdownTimer();
    }

    void CountdownTimer()
    {
        timer += Time.deltaTime;
        if (timer >= appearIntervalTime)
        {
            ToggleOnOff(!isVisible);
            timer = 0f;
        }
    }

    void ToggleOnOff(bool status)
    {
        isVisible = status;
        if (status)
        {
            myCollider.enabled = status;
            StartCoroutine(ChangeSomeValue(1f, 0f, 0.5f, status));
        }
        else
            StartCoroutine(ChangeSomeValue(0f, 1f, 0.5f, status));
    }

    public IEnumerator ChangeSomeValue(float oldValue, float newValue, float duration, bool status)
    {
        float someValue;
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            someValue = Mathf.Lerp(oldValue, newValue, t / duration);
            meshRenderer.material.SetFloat("_DissolveAmount", someValue);
            yield return null;
        }
        myCollider.enabled = status;
    }
}
