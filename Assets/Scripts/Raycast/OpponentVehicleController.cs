
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentVehicleController : MonoBehaviour
{
    private struct structAI
    {
        public Transform checkpoints;
        public int idx;
        public Vector3 directionSteer;
        public Quaternion rotationSteer;
    }

    [Header("Rigidbody")]
    [SerializeField] private Vector3 centerOfMass;
    [Header("Acceleration")]
    [SerializeField] private float accelSpeed;
    [SerializeField] private ForceMode accelMode;
    [SerializeField] private Vector3 accelOrigin;
    [Header("Turning")]
    [SerializeField] private float turnSpeed;
    [SerializeField] private ForceMode turnMode;
    [Header("Traction")]
    [SerializeField] private float normalTractionConstant;
    [SerializeField] private float driftTractionConstant;
    [SerializeField] private ForceMode tractionMode;
    [Header("Debug")]
    [SerializeField] private float velocityDebugRayLength;
    [SerializeField] private float currentSpeed;

    public int currentCP;
    private Rigidbody rb;
    private structAI ai;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
        ai.checkpoints = GameObject.FindWithTag("AllCheckpoints").transform;
        ai.idx = 0;
    }



    private void FixedUpdate()
    {
        
        ai.directionSteer = ai.checkpoints.GetChild(ai.idx).position - this.transform.position;
        ai.rotationSteer = Quaternion.LookRotation(ai.directionSteer);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, ai.rotationSteer, turnSpeed);


        rb.AddRelativeForce(Vector3.forward * accelSpeed, ForceMode.Acceleration);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint") == true)
        {
            ai.idx = CalcNextCheckpoint();
        }
    }
    private int CalcNextCheckpoint()
    {
        int curr = ExtractNumberFromString(ai.checkpoints.GetChild(ai.idx).name);
        int next = curr + 1;
        if (next > ai.checkpoints.childCount - 1)
            next = 0;

        Debug.Log(string.Format("current checkpoint {0}, next {1}", curr, next));
        currentCP = curr;
        return next;
    }
    private int ExtractNumberFromString(string s1)
    {
        return System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(s1, "[^0-9]", ""));
    }

}
