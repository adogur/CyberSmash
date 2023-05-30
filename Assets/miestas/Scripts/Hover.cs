using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hover : MonoBehaviour
{
    public float amplitude = 2f;
    public float speed = 1f;
    private float aukstis;
    void Start()
    {
        aukstis = transform.position.y;
    }
    void Update()
        {
            float y = amplitude * Mathf.Sin(Time.time * speed);
            transform.position = new Vector3(transform.position.x, aukstis + y, transform.position.z);
        }
    }