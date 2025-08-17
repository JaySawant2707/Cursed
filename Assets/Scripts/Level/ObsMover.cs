using UnityEngine;
using System.Collections;

public class ObsMover : MonoBehaviour
{
    [Header("Distances")]
    public float upDownDistance = 3f;  
    public float forwardDistance = 5f; 

    [Header("Settings")]
    public float moveSpeed = 2f;  
    public float waitTime = 1f; 
    private void Start()
    {
        StartCoroutine(MoveSequence());
    }

    private IEnumerator MoveSequence()
    {
        yield return MoveObject(Vector3.up, upDownDistance);
        yield return new WaitForSeconds(waitTime);

        yield return MoveObject(Vector3.right, forwardDistance);
        yield return new WaitForSeconds(waitTime);

        yield return MoveObject(Vector3.down, upDownDistance);

        Destroy(this.gameObject, 2f);
    }

    private IEnumerator MoveObject(Vector3 direction, float distance)
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + direction * distance;

        float elapsed = 0f;
        float duration = distance / moveSpeed;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos; 
    }
}
