using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBar;   
    public float maxMana = 100f;
    private float _currentMana;
    private bool _isRegeneretion = false;

    void Start()
    {
        SetMaxMana();
    }

    void Update()
    {
        if (_currentMana <= maxMana && !_isRegeneretion)
        {
            StartCoroutine(RegenerateMana(2));
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

    public IEnumerator RegenerateMana(float amount)
    {
        _isRegeneretion = true;
        while (_currentMana < maxMana)
        {
            _currentMana += amount;
            _currentMana = Mathf.Clamp(_currentMana, 0, maxMana);
            UpdateManaBar();
            yield return new WaitForSeconds(1f);
        }
        _isRegeneretion = false;
    }

    private void UpdateManaBar()
    {
        manaBar.fillAmount = _currentMana / maxMana;
    }
}