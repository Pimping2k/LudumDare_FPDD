using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SatanPleasureComponent : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float damagePerInterval = 0.1f;
    [SerializeField] private float damageInterval = 0.1f;
    [SerializeField] private Image healthBar;

    public float currentHealth;
    private Coroutine damageCoroutine;

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void OnEnable()
    {
        damageCoroutine = StartCoroutine(AutoDamageCoroutine());
    }

    IEnumerator AutoDamageCoroutine()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(damageInterval);
            TakeDamage(damagePerInterval);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            StopCoroutine(damageCoroutine);
            StopAllCoroutines();
        }
    }
    
    public void IncreaseHealth(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            StopCoroutine(damageCoroutine);
            StopAllCoroutines();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}