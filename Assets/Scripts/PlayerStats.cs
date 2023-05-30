using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    
    public GameObject explosion;
    public GameObject shield;
    public bool shieldActive;
    private float currentHealth;

    public GameObject canvas;

    public HealthBar healthBar;

    public GameOverScript gameOver;

    public PopupScript popups;

    public AudioSource healSound;
    public AudioSource damageSound;

    public ParticleSystem healParticles;
    public ParticleSystem damageParticles;
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("UI");
        healthBar = canvas.GetComponentInChildren<HealthBar>();
        gameOver= canvas.GetComponentInChildren<GameOverScript>();
        gameOver.gameObject.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
        shield.SetActive(false);
        shieldActive= false;
    }

    public void TakeDamage(float amount)
    {
        if (!shieldActive)
        {
            currentHealth -= amount;
            healthBar.SetSlider(currentHealth);
            damageSound.Play();
            Instantiate(damageParticles, transform.position, Quaternion.identity);
            Debug.Log("damage: " + amount);
            //popups.type = 2;
            //popups.Pickup();
        }
    }
    public void Heal(float amount)
    {
        currentHealth += amount;
        healthBar.SetSlider(currentHealth);
        healSound.Play();
        Instantiate(healParticles, transform.position, Quaternion.identity);
        //popups.type = 1;
        //popups.Pickup();
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

    private void Die()
    {
        Debug.Log("You died!");
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameOver.Die();
        Destroy(gameObject);
    }

    public void Shield(float duration)
    {
        StartCoroutine(ShieldPowerup(duration));
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
