using System.Collections;
using UnityEngine;

public class SatanPleasureComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private int damagePerInterval = 1;  
    [SerializeField] private float damageInterval = 4f;  
    
    private Coroutine damageCoroutine;

    
    void Awake()
    {
        currentHealth = maxHealth;
    }
    
    void Start()
    {
        damageCoroutine = StartCoroutine(AutoDamageCoroutine());
    }
    
    // Корутин для периодического уменьшения здоровья
    IEnumerator AutoDamageCoroutine()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(damageInterval);  
            TakeDamage(damagePerInterval);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;  
        
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
        }
    }
}
