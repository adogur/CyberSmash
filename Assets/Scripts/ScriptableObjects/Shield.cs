using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Shield")]
public class Shield : PowerupEffect
{
    public float duration = 5f;
    
    public override void Apply(GameObject target)
    {
        var stats = target.GetComponent<PlayerStats>();
        stats.Shield(duration);
    }

}
