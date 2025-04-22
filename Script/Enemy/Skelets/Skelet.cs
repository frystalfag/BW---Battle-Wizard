using UnityEngine;
using UnityEngine.AI;
public abstract class Skelet : MonoBehaviour
{
    [Header("Enemy Controller")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float triggerRadius = 10f;
    [SerializeField] private float attackDistance = 0.5f;
    [SerializeField] private float distanceToPlayer;
    
    [Header("Movement")]
    private static float moveSpeed = 1f;
    
    [Header("Stats")]
    public int level { get; protected set; }
    public float damage { get; protected set; }
    public string type { get; protected set; }
    private Spawner spawner;
    
    [Header("Player")]
    private Transform playerTransform;
    private GameObject player;
    
    [Header("Context")]
    private CharacterController controller;
    private CharacterContext character;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        character = new CharacterContext();
    }
    
    private void Start()
    {
        if (agent != null)
        {
            agent.speed = moveSpeed * 3.5f;
        }
        
        character.ChangeState(new MovementState(animator, 0, character));
    }
    
    public void Initialize(Spawner spawner, int level, float damage, float attackDistance, float triggerRadius)
    {
        this.spawner = spawner;
        this.level = level;
        this.damage = damage;
        this.attackDistance = attackDistance;
        this.triggerRadius = triggerRadius;
    }
    
    public void SetTarget(Transform Player)
    {
        this.playerTransform = Player;
    }
    
    public void Move()
    {
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer <= triggerRadius && distanceToPlayer > attackDistance)
        {
            ChasePlayer();
        }
        else if (agent != null && playerTransform != null)
        {
            StopChasing();
            Attack();
        }
        else
        {
            StopChasing();
        }
    }
    
    private void ChasePlayer()
    {
        if (!agent.hasPath || agent.remainingDistance > attackDistance)
        {
            agent.SetDestination(playerTransform.position);
            if (!(character.GetCurrentState() is AttackState) && 
                (!(character.GetCurrentState() is MovementState) || 
                 ((MovementState)character.GetCurrentState()).movementSpeed != moveSpeed))
            {
                character.ChangeState(new MovementState(animator, moveSpeed, character));
            }
        }
    }
    
    private void StopChasing()
    {
        agent.ResetPath();
        character.ChangeState(new MovementState(animator, 0f, character));
    }
    
    public abstract void Attack();

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
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

    protected virtual void Update()
    {
        if (playerTransform == null)
        {
            player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
            return;
        }
        
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        
        if (distanceToPlayer <= attackDistance)
        {
            if (!(character.GetCurrentState() is AttackState))
            {
                StopChasing();
            }
        }
        else if (distanceToPlayer <= triggerRadius)
        {
            ChasePlayer();
        }
        else
        {
            StopChasing();
        }
        
        character.UpdateState();
    }
}