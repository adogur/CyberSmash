using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    public GameObject explosion;
    public GameObject shield;
    public bool shieldActive;
    private float currentHealth;

    public AudioSource healSound;
    public AudioSource damageSound;

    public ParticleSystem healParticles;
    public ParticleSystem damageParticles;
    private void Start()
    {
        shield.SetActive(false);
        shieldActive = false;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (!shieldActive)
        {
            currentHealth -= amount;
            damageSound.Play();
            Instantiate(damageParticles, transform.position, Quaternion.identity);
            Debug.Log("Enemy damage: " + amount);
        }
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        healSound.Play();
        Instantiate(healParticles, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Shield(float duration)
    {
        StartCoroutine(ShieldPowerup(duration));
    }
    private void Die()
    {
        Debug.Log("Enemy died!");
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public IEnumerator ShieldPowerup(float duration)
    {
        shieldActive = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(duration);
        shieldActive = false;
        shield.SetActive(false);
    }
}
