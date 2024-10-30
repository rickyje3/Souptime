using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public AudioSource bounce;

    private void OnCollisionEnter(Collision collision)
    {
        bounce.Play();
    }
}
