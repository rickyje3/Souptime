using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PouringTilt : MonoBehaviour
{
    [Tooltip("Tilt range, 0 - 180 degrees")]
    [Range(0, 1)] public float threshold = 0.0f;

    [Tooltip("Particle system for pouring effect")]
    public ParticleSystem pouringParticle;

    [Serializable] public class TiltEvent : UnityEvent<MonoBehaviour> { }

    // Threshold has been broken
    public TiltEvent OnBegin = new TiltEvent();

    // Threshold is no longer broken
    public TiltEvent OnEnd = new TiltEvent();

    private bool withinThreshold = false;

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
                StartPouring();
            }
            else
            {
                OnEnd.Invoke(this);
                StopPouring();
            }
        }
    }

    private void StartPouring()
    {
        if (pouringParticle != null && !pouringParticle.isPlaying)
        {
            pouringParticle.Play();
        }
    }

    private void StopPouring()
    {
        if (pouringParticle != null && pouringParticle.isPlaying)
        {
            pouringParticle.Stop();
        }
    }
}

