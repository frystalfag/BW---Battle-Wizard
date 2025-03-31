using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    
    [SerializeField] private float triggerRadius = 10f;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float attackDistance = 0.5f;
    
    [SerializeField] private float distanceToPlayer;
    
    private static float movementSpeed = 1f;
    
    private readonly int runAnimParam = Animator.StringToHash("Run");
    
    private Transform playerTransform;
    
    private void Awake()
    {
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponent<Animator>();
    }
    
    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogWarning($"Enemy {gameObject.name} couldn't find player with tag '{playerTag}'");
        }
        
        if (agent != null)
        {
            agent.speed = movementSpeed;
        }
    }
    
    private void Update()
    {
        if (!IsAgentReady() || playerTransform == null) return;
        
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer < triggerRadius)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }
    }
    
    private bool IsAgentReady()
    {
        return agent != null && agent.enabled && agent.isOnNavMesh;
    }
    
    private void ChasePlayer()
    {
        if (!agent.hasPath || agent.remainingDistance > attackDistance)
        {
            agent.SetDestination(playerTransform.position);
        }
        
        animator.SetBool(runAnimParam, true);
    }
    
    private void StopChasing()
    {
        agent.ResetPath();
    }
    
    public static void ChangeSpeed(float newSpeed)
    {
        movementSpeed = Mathf.Max(0, newSpeed); 
    }
    
    public void UpdateSpeed()
    {
        if (agent != null)
        {
            agent.speed = movementSpeed;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}