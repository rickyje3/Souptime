using System;
using UnityEngine;
using UnityEngine.Events;

public class PourTilt : MonoBehaviour
{

    [Tooltip("Tilt range, 0 - 180 degrees")]
    [Range(0, 1)] public float threshold = 0.0f;

    [Tooltip("Particle system for pouring effect")]
    public ParticleSystem pouringParticle;

    // Threshold has been broken
    public UnityEvent<MonoBehaviour> OnBegin = new UnityEvent<MonoBehaviour>();

    // Threshold is no longer broken
    public UnityEvent<MonoBehaviour> OnEnd = new UnityEvent<MonoBehaviour>();

    private bool withinThreshold = false;

    // Update method called once per frame
    private void Update()
    {
        CheckOrientation();
    }

    private void CheckOrientation()
    {
        float similarity = Vector3.Dot(-transform.up, Vector3.up);
        similarity = Mathf.InverseLerp(-1, 1, similarity);

        bool thresholdCheck = similarity >= threshold;

        if (withinThreshold != thresholdCheck)
        {
            withinThreshold = thresholdCheck;

            if (withinThreshold)
            {
                OnBegin.Invoke(this);
                StartPouringEffect();
            }
            else
            {
                OnEnd.Invoke(this);
                StopPouringEffect();
            }
        }

        // Adjust particle system rotation to match pot's rotation
        if (pouringParticle != null && pouringParticle.isPlaying)
        {
            AdjustParticleRotation();
        }
    }

    private void StartPouringEffect()
    {
        if (pouringParticle != null && !pouringParticle.isPlaying)
        {
            pouringParticle.Play();
        }
    }

    private void StopPouringEffect()
    {
        if (pouringParticle != null && pouringParticle.isPlaying)
        {
            pouringParticle.Stop();
        }
    }

    private void AdjustParticleRotation()
    {
        // Get the desired direction based on the pot's rotation
        Vector3 potUp = transform.up; // The "up" vector of the pot (the direction of the handle in most cases)

        // Rotate the particle system to align with the pot's up direction
        // If the pot is tilted, the emitter will rotate accordingly
        Quaternion targetRotation = Quaternion.LookRotation(potUp);

        // Apply the rotation to the particle system
        pouringParticle.transform.rotation = targetRotation;
    }
}
