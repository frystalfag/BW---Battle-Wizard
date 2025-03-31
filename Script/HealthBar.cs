using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100f;
    private float _currentHealth;

    void Start()
    {
        SetMaxHealth();
    }

    public float CurHealth
    {
        get{return _currentHealth;}
        set
        {
            _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
            UpdateHealthBar();
        }
    }

    private void SetMaxHealth()
    {
        _currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = _currentHealth / maxHealth;
    }
}