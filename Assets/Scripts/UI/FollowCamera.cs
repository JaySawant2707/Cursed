using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(-Input.mousePosition.x + Screen.width, -Input.mousePosition.y + Screen.height, -5));
    }
}
