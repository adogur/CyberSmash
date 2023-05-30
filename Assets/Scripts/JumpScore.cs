using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpScore : MonoBehaviour
{
    [SerializeField]
    private JumpStart start;
    public float timer;
    public TMP_Text text;
    public float score;
    private void Update()
    {
        if(start.jumping)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            score = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            score = Mathf.Round(timer * 100);
            text.SetText("Jump score: " + score);
            start.jumping = false;
            gameObject.SetActive(false);
        }
    }

}
