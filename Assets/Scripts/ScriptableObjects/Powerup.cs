using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect effect;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        effect.Apply(other.gameObject);
    }
}
