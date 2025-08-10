using UnityEngine;
using UnityEngine.Events;

public class FallCrackHandler : MonoBehaviour
{
    [Header("References")]
    public Renderer girlRenderer;
    [Tooltip("[minor, major, shatter]")]
    public AudioClip[] impactSounds;
    public UnityEvent onShatter;

    [Header("Impact Thresholds")]
    public float minorThreshold = 5f;
    public float majorThreshold = 10f;
    public float fatalThreshold = 15f;

    private CharacterController controller;
    private MaterialPropertyBlock propBlock;
    private float prevYVelocity;
    private bool wasGrounded;
    private int crackLevel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        propBlock = new MaterialPropertyBlock();
        girlRenderer.GetPropertyBlock(propBlock);
        prevYVelocity = 0f;
        wasGrounded = controller.isGrounded;
        crackLevel = 0;
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;
        float currentYVel = controller.velocity.y;

        if (!wasGrounded && isGrounded)
        {
            float impactSpeed = Mathf.Abs(prevYVelocity);
            HandleImpact(impactSpeed);
            //Debug.Log("handled impact" + impactSpeed);
        }

        wasGrounded = isGrounded;
        prevYVelocity = currentYVel;
    }

    void HandleImpact(float speed)
    {
        if (speed >= fatalThreshold)
        {
            //Debug.Log("fatal");
            PlayImpactSound(2);
            onShatter.Invoke();
            return;
        }
        else if (speed >= majorThreshold)
        {
            //Debug.Log("major");
            crackLevel = Mathf.Max(crackLevel, 2);
            PlayImpactSound(1);
        }
        else if (speed >= minorThreshold)
        {
            //Debug.Log("minor");
            crackLevel = Mathf.Max(crackLevel, 1);
            PlayImpactSound(0);
        }

        UpdateCrackVisual();
    }

    void UpdateCrackVisual()
    {
        float intensity = crackLevel / 2f;
        propBlock.SetFloat("_CrackIntensity", intensity);
        girlRenderer.SetPropertyBlock(propBlock);
    }

    void PlayImpactSound(int index)
    {
        if (impactSounds != null && index < impactSounds.Length)
        {
            AudioSource.PlayClipAtPoint(impactSounds[index], transform.position);
        }
    }
}