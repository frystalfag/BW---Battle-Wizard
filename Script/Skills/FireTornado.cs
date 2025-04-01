using Unity.VisualScripting;
using UnityEngine;

public class FireTornado : Spell
{
    public float duration = 5f;
    public float damagePerSecond = 20f;
    public static float manaCost = 20f;
    [Serialize]private GameObject tornado; 
    
    private float lifetime;

    void Start()
    {
        lifetime = duration;
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public override void CastSpell()
    {
        Instantiate(gameObject);
    }

    public void OnTriggerStay(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            HealthBar EnemyHealth = other.GetComponent<HealthBar>();
        
            if (EnemyHealth != null)
            {
                EnemyHealth.TakeDamage(damagePerSecond * Time.deltaTime);
            }    
        }
    }
}
