using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public LayerMask groundLayer;

    [Header("Fragility")]
    public float maxSafeFallSpeed = -15f; // if fall speed exceeds this, player shatters
    public GameObject shatteredVersion;

    private Rigidbody rb;
    private bool isGrounded;
    private float fallVelocityBeforeLanding;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
    }

    void Update()
    {
        Move();
        Jump();
        GroundCheck();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        Vector3 movement = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y, 0f);
        rb.linearVelocity = movement;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0f);
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;
        bool wasGrounded = isGrounded;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, groundLayer);

        if (!isGrounded)
        {
            fallVelocityBeforeLanding = rb.linearVelocity.y;
        }
        else if (!wasGrounded && fallVelocityBeforeLanding < maxSafeFallSpeed)
        {
            Shatter();
        }
    }

    void Shatter()
    {
        if (shatteredVersion != null)
        {
            Instantiate(shatteredVersion, transform.position, transform.rotation);
        }

        // Add particle/sound effects here if needed
        Destroy(gameObject);
    }
}
