using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public Vector3 move;
    
    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
