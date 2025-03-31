using UnityEngine;
using UnityEngine.AI;
public abstract class Skelet : MonoBehaviour
{
    [Header("Enemy Controller")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private float triggerRadius = 10f;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float attackDistance = 0.5f;
    [SerializeField] private float distanceToPlayer;
    
    private static float movementSpeed = 1f;
    
    public int level { get; protected set; }
    public float damage { get; protected set; }
    public string type { get; protected set; }
    private Spawner spawner;
    
    private readonly int runAnimParam = Animator.StringToHash("Run");
    
    private Transform playerTransform;
    
    

    public void Initialize(Spawner spawner, int level, float damage, float attackDis, float radius)
    {
        level = level;
        spawner = spawner;
        damage = damage;
        
        triggerRadius = radius;
        attackDistance = attackDis;
        
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void Move()
    {
        if (agent != null)
        {
            
        }
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
        animator.SetBool(runAnimParam, false);
        agent.ResetPath();
    }


    public abstract void Atack();

    public void LevelUp()
    {
        Debug.Log("LevelUp");
    }

    public void CreateModel()
    {
        Debug.Log("CreateModel");
    }

    public void Die()
    {
        spawner.DestroyMob(this);
        Destroy(gameObject);
    }
}