using UnityEngine;
using Unity.VisualScripting;
public class FireBall : Spell
{
    private float damage = 15;
    private float duration = 1.5f;
    private float speed = 3f;
    private float lifetime;
    [Serialize]private GameObject fireBall;
    public float ManaCost = 20f;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public override void CastSpell()
    {
        Debug.Log("fireBall");
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = GetComponent<Enemy>();
        if (enemy != null)
        {
            HealthBar EnemyHealth = GetComponent<HealthBar>();
            
            if (EnemyHealth != null)
            {
                EnemyHealth.TakeDamage(damage);
            } 
            Destroy(gameObject);
        }
    }
}
