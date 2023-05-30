using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{

    public Transform[] wheels = new Transform[4];
    public Rigidbody rb;
    public float speed;
    public float steerAngle = 60;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        if (rb.velocity != Vector3.zero)
        {
            for (int i = 0; i < 4; i++)
            {
                wheels[i].Rotate(rb.velocity.x * speed * 360 * Time.deltaTime, 0, 0);
            }
        }
        if (axisH != 0) {
            Transform l = wheels[0];
            wheels[0].localEulerAngles = new Vector3(0, steerAngle * axisH - wheels[0].localEulerAngles.z, 0);

            wheels[1].localEulerAngles = new Vector3(0, steerAngle * axisH - wheels[1].localEulerAngles.z, 0);
        }
    }
}
