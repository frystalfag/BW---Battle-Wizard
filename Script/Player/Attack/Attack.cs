using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.TextCore.Text;

public class Attack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 10f;
    public float attackCooldown = 1.5f;

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 2f;
    public int bulletDamage = 10;
    public int bulletPoolSize = 10;

    [Header("References")]
    public Transform firePoint;
    public LayerMask enemyLayer;

    private CharacterContext characterContext;
    private bool canAttack = true;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    
    void Start()
    {
        characterContext = GetComponent<CharacterContext>();
        InitializeBulletPool();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            TryAttack();
        }
    }
    
    void TryAttack()
    {
        if (Camera.main == null) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            PerformAttack(hit.point);
        }
    }

    void PerformAttack(Vector3 targetPosition)
    {
        characterContext.ChangeState(new AttackState(characterContext));
        canAttack = false;

        StartCoroutine(FireBullet(targetPosition));
        StartCoroutine(AttackCooldown());
    }

    IEnumerator FireBullet(Vector3 targetPosition)
    {
        yield return new WaitForSeconds(0.5f); 

        Vector3 direction = (targetPosition - firePoint.position).normalized;
        GameObject bullet = GetBulletFromPool();

        if (bullet == null) yield break;

        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(direction);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = direction * bulletSpeed;
        StartCoroutine(ReturnBulletToPool(bullet));
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void InitializeBulletPool()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    GameObject GetBulletFromPool()
    {
        if (bulletPool.Count == 0) return null;

        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    IEnumerator ReturnBulletToPool(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLifetime);
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
