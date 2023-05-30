using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStart : MonoBehaviour
{
    public bool jumping = false;
    public GameObject scoreO;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            jumping = true;
            scoreO.gameObject.SetActive(true);
        }
    }
}
