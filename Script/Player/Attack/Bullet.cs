using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    

    private void OnTriggerEnter(Collider other)
    {
        HealthBar enemy = other.GetComponent<HealthBar>();
        if (enemy != null)
        {
            if (other.CompareTag("Enemy"))
            {
                enemy.TakeDamage(damage);
                gameObject.SetActive(false);    
            }
        }
    }
}