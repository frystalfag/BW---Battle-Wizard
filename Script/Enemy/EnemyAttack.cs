using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 2f; 
    public float attackCooldown = 1.5f; 
    private float lastAttackTime;

    void Start()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        
    }
    
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player") && Time.time > lastAttackTime + attackCooldown)
            {
                Attack(col.gameObject);
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack(GameObject player)
    {
        animator.SetBool("Run", false);
        animator.SetTrigger("Attack");
        
        
        HealthBar playerHealth = player.GetComponent<HealthBar>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(10);
        }
    }
}