using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField] float runSpeed = 3f;
    public bool canChasePlayer = true;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRadius = 1f;
    [SerializeField] int attackDamage = 999;

    Transform player;
    NavMeshAgent agent;
    Animator animator;

    void Awake()
    {
        if (!agent) agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        if (canChasePlayer)
        {
            ChaseState();
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    void ChaseState()
    {
        agent.SetDestination(player.position);
        agent.speed = runSpeed;
        animator.SetFloat("Speed", runSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("SplashAttack");
            //other.gameObject.GetComponent<PlayerHealth>().TakeDamage(999);
        }
    }

    public void AttackPlayer() //Called in animation event in attack animation of zombie
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRadius);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(attackDamage);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
