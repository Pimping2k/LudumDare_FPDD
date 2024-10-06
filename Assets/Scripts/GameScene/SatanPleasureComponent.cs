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

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBar(); 
    }
    
    void Start()
    {
        StartCoroutine(AutoDamageCoroutine());
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
