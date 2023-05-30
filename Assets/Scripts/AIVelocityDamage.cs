using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVelocityDamage : MonoBehaviour
{
    [SerializeField]
    private EnemyStats enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 20)
        {
            if (collision.relativeVelocity.magnitude > 50)
            {
                enemy.TakeDamage(40 * 0.02f);
                return;
            }
            enemy.TakeDamage(collision.relativeVelocity.magnitude * 0.02f);
        }
        else
            return; 
    }

}
