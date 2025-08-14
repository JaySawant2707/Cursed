using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] Vector3 rotationSpeed = new Vector3(0f, 50f, 0f);

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
