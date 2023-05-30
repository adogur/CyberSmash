using UnityEngine;

public class DamageItem : MonoBehaviour
{
    public float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}
