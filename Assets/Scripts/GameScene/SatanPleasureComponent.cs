using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SatanPleasureComponent : MonoBehaviour
{
    public static SatanPleasureComponent Instance;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float damagePerInterval = 0.1f;
    [SerializeField] private float damageInterval = 0.1f;
    [SerializeField] private Image healthBar;

    [SerializeField] private Animation cameraAnim;
    [SerializeField] private Animation fadeInAnim;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip losingSound;
    public float currentHealth { get; private set; }
    private Coroutine damageCoroutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentHealth = maxHealth;
            UpdateHealthBar();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnEnable()
    {
        damageCoroutine = StartCoroutine(AutoDamageCoroutine());
    }

    private void OnDisable()
    {
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
        }
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
        
        if (currentHealth <= 0 && damageCoroutine != null)
        {
            _audioSource.PlayOneShot(losingSound);
            cameraAnim.Play("LostAnim");
            fadeInAnim.Play("LostIn");
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    public void IncreaseHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
