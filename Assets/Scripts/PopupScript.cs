using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    public GameObject heal;
    public GameObject boost;
    public GameObject damage;

    public int type = 0;

    private void Start()
    {
        heal.SetActive(false);
        boost.SetActive(false); 
        damage.SetActive(false);

    }

    public void Pickup()
    {
        if (type == 1) {
            StartCoroutine(HealCoroutine());
        }
        else if (type == 2) { StartCoroutine(DamageCoroutine()); }
        else if (type == 3) { StartCoroutine(BoostCoroutine()); }
        
    }

    IEnumerator HealCoroutine()
    {
        heal.SetActive(true);
        yield return new WaitForSeconds(2);
        heal.SetActive(false);
    }

    IEnumerator DamageCoroutine()
    {
        damage.SetActive(true);
        yield return new WaitForSeconds(2);
        damage.SetActive(false);
    }

    IEnumerator BoostCoroutine()
    {
        boost.SetActive(true);
        yield return new WaitForSeconds(2);
        boost.SetActive(false);
    }

}
