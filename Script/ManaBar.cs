using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBar;   
    public float maxMana = 100f;
    private float _currentMana;

    void Start()
    {
        SetMaxMana();
    }

    void Update()
    {
        if (_currentMana <= maxMana)
        {
            RegenerateMana(2);
        }
    }
    
    public float CurMana
    {
        get{return _currentMana;}
        set
        {
            _currentMana = Mathf.Clamp(_currentMana, 0, maxMana);
            UpdateManaBar();
        }
    }

    private void SetMaxMana()
    {
        _currentMana = maxMana;
        UpdateManaBar();
    }

    public void UseMana(float amount)
    {
        _currentMana -= amount;
        _currentMana = Mathf.Clamp(_currentMana, 0, maxMana);
        UpdateManaBar();
    }

    public void RegenerateMana(float amount)
    {
        _currentMana += amount;
        _currentMana = Mathf.Clamp(_currentMana, 0, maxMana);
        UpdateManaBar();
    }

    private void UpdateManaBar()
    {
        manaBar.fillAmount = _currentMana / maxMana;
    }
}