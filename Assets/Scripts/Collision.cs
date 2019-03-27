using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject effect;
    public GameObject explosion;
    public int HP;

    float delay = 0f;

    private void Update()
    {
        delay -= Time.deltaTime;
    }

    //collision enter
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //get rigidbody
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

        //get velocity
        float velocity = rigidbody.velocity.magnitude;

        //if velocity > 1
        if (velocity > 1)
        {
            //effect
            if (effect != null)
                Instantiate(effect, rigidbody.position, transform.rotation);

            //particle system
            if (gameObject.GetComponentInChildren<ParticleSystem>() != null)
            {
                gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }

            //sound
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().pitch = Random.Range(.8f, 16f);
                gameObject.GetComponent<AudioSource>().Play();

            }

            //explosion
            if (explosion != null)
            {
                //create explosion
                GameObject explode = Instantiate(explosion, rigidbody.position, Quaternion.identity) as GameObject;
                
                //delete object
                Destroy(gameObject);
                Destroy(explode, 2);
            }
        }

    }
}
