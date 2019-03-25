using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision : MonoBehaviour
{
    public AudioSource collisionSound;
    public GameObject effect;
    public ParticleSystem particleSys;
    public Rigidbody rb;

    float delay = 1f;

    //[Tooltip("Smallest velocity for sound to play")]

    // public float impactVelocity;

    private void Update()
    {
        delay -= Time.deltaTime;
    }


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        float velocity = rb.velocity.magnitude;

         if (velocity >  1)
         {
        print("PLaying effect");
            if(effect != null)
                Instantiate(effect, rb.position, transform.rotation);

            if (particleSys != null)
            {
                //Instantiate(particleSys, rb.position, transform.rotation);
                particleSys.Play();
                delay = 7f;
            }


        }




        collisionSound.pitch = Random.Range(0.2f, .8f);

        print("Velocity = " + rb.velocity.magnitude);
        print("Pitch = " + collisionSound.pitch);


        //if (velocity > 0 && velocity < 1)
        //{
        //    collisionSound.volume = .10f;
        //}
        //if (velocity > 1 && velocity < 5)
        //{
        //    collisionSound.volume = .35f;
        //}
        //if (velocity > 5 && velocity < 8)
        //{
        //    collisionSound.volume = .55f;
        //}
        //if (velocity > 8 && velocity < 20)
        //{
        //    collisionSound.volume = .75f;
        //}
        //if (velocity > 20)
        //{
        //    collisionSound.volume = 1f;
        //}

        if (velocity > 1)
        {
            
            collisionSound.Play();
            
        }

    }
}
