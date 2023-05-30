using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWheelScript : MonoBehaviour
{
    private Rigidbody rb;

    public bool WheelFrontLeft;
    public bool WheelFrontRight;
    public bool WheelRearLeft;
    public bool WheelRearRight;

    [Header("Suspension")]
    public float restLength;
    public float springTravel;
    public float springStiffness;
    public float damperStiffness;

    private float minLength;
    private float maxLength;
    private float lastLength;
    private float springLength;
    private float springForce;
    private float damperForce;
    private float springVelocity;
    public float power;

    private Vector3 suspensionForce;
    private Vector3 wheelVelocityLocal;
    private float fx;
    private float fy;

    [Header("Wheel")]
    public float wheelRadius;
    public float steerAngle;

    void Start()
    {
        rb = transform.root.GetComponent<Rigidbody>();

        minLength = restLength - springTravel;
        maxLength = restLength + springTravel;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y + steerAngle, transform.localRotation.z);

        Debug.DrawRay(transform.position, -transform.up * (springLength + wheelRadius), Color.green);
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, maxLength + wheelRadius))
        {
            lastLength = springLength;

            springLength = hit.distance - wheelRadius;
            springLength = Mathf.Clamp(springLength, minLength, maxLength);
            springVelocity = (lastLength - springLength) / Time.fixedDeltaTime;
            springForce = springStiffness * (restLength - springLength);
            damperForce = damperStiffness * springVelocity;

            suspensionForce = (springForce + damperForce) * transform.up;

            wheelVelocityLocal = transform.InverseTransformDirection(rb.GetPointVelocity(hit.point));

            fx = Input.GetAxis("Vertical") * power * 10;
            fy = wheelVelocityLocal.x * springForce;

            rb.AddForceAtPosition(suspensionForce + (fx * transform.forward) + (fy * -transform.right), hit.point);
        }

    }
}