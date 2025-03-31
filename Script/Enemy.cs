using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float currentHealth;
    public Animator animator;
    private HealthBar healthBar;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        healthBar = gameObject.GetComponent<HealthBar>();
        // healthBar.CurHealth = 56;
        // GameMenager.Instance.AddScore(10);
    }

    void Update()
    {
        currentHealth = healthBar.CurHealth;
        if (currentHealth <= 0)
        {
            Debug.Log(currentHealth);
            StartCoroutine(Die());    
        }
    
    }
    IEnumerator Die()
    {
        animator.SetBool("Die", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}