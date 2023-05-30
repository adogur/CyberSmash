using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDamage : MonoBehaviour
{
    [SerializeField]
    private PlayerStats player;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 20)
        {
            if (collision.relativeVelocity.magnitude > 50)
            {
                player.TakeDamage(40 * 0.2f);
                return;
            }
            player.TakeDamage(collision.relativeVelocity.magnitude * 0.2f);
        }
        else
            return; 
    }

}
