using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioSource collisionSound;
    public ParticleSystem effect;
    public Rigidbody rb;

    //[Tooltip("Smallest velocity for sound to play")]

    // public float impactVelocity;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        float velocity = rb.velocity.magnitude;

        


        print("Velocity = " + rb.velocity.magnitude);

        if (velocity > 0 && velocity < 1)
        {
            collisionSound.volume = .10f;
        }
        if (velocity > 1 && velocity < 5)
        {
            collisionSound.volume = .35f;
        }
        if (velocity > 5 && velocity < 8)
        {
            collisionSound.volume = .55f;
        }
        if (velocity > 8 && velocity < 20)
        {
            collisionSound.volume = .75f;
        }
        if (velocity > 20)
        {
            collisionSound.volume = 1f;
        }

        collisionSound.Play();

    }
}
