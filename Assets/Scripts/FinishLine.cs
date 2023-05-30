using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject canvas;
    public GameOverScript gameOver;

    public void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("UI");
        gameOver = canvas.GetComponentInChildren<GameOverScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver.Finish();
        }
    }
}
