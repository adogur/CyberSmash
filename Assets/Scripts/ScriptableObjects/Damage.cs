using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Damage")]
public class Damage : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        var stats = target.GetComponent<PlayerStats>();
        stats.TakeDamage(amount);
    }
}
