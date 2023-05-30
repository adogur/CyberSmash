using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundScript : MonoBehaviour
{
    public float minPitch = 0.9f;
    public float maxPitch = 1.5f;

    public float maxSpeed = 3f;

    public Rigidbody target;

    private Vector3 previousTargetPosition;
    private Vector3 targetVelocity;

    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        UpdateVelocity();
        UpdatePreviousTargetPosition();
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        UpdateAudioPitch();

    }

    void UpdateAudioPitch()
    {
        var clampedSpeed = Mathf.Clamp(targetVelocity.magnitude, 0, maxSpeed);
        var pitchPercentage = clampedSpeed / maxSpeed;
        var pitch = Mathf.Lerp(minPitch, maxPitch, pitchPercentage);

        audio.pitch = pitch;   
    }

    void UpdateVelocity()
    {
        var targetPosition = target.position;
        targetVelocity = (targetPosition - previousTargetPosition) / Time.deltaTime;
    }

    void UpdatePreviousTargetPosition()
    {
        previousTargetPosition = target.position;
    }

}
