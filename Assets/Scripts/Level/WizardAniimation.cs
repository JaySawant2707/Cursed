using UnityEngine;

public class WizardAniimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void IdleAnim()
    {
        animator.SetBool("isWalking", false);
    }

    public void WalkAnim()
    {
        animator.SetBool("isWalking", true);
    }
}
