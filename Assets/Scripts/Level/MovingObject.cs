using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] GameObject movableObject;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float stopDelay = 1f;
    [SerializeField] bool repeat = true;

    Transform targetPoint;
    float timer;

    void Start()
    {
        targetPoint = pointB;
        movableObject.transform.position = pointA.position;
    }

    void Update()
    {
        movableObject.transform.position = Vector3.MoveTowards(movableObject.transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(movableObject.transform.position, targetPoint.position) < 0.1f && repeat)
        {
            timer += Time.deltaTime;
            if (timer >= stopDelay)
            {
                if (targetPoint == pointA)
                {
                    targetPoint = pointB;
                }
                else
                {
                    targetPoint = pointA;
                }
                timer = 0f;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("                   " +collision.gameObject.name);
            collision.gameObject.transform.parent = this.transform;
        }
    }
}
