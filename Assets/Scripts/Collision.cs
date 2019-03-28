using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject effect;
    public GameObject explosion;
    public float HP;

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
            //decrease HP
            HP -= velocity * 10f;
            //effect
            if (effect != null)
                Instantiate(effect, rigidbody.position, transform.rotation);

            //particle system
            if (gameObject.GetComponentInChildren<ParticleSystem>() != null)
            {
                if(gameObject.name=="Desk")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if(gameObject.name=="mouse")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "tower" && HP<=50)
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "Chair")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "Keyboard")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "DisplayScreen1" || gameObject.name=="DisplayScreen2")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
            }

            //sound
            if (gameObject.GetComponent<AudioSource>() != null)
            {
                gameObject.GetComponent<AudioSource>().pitch = Random.Range(.5f, 1f);
                gameObject.GetComponent<AudioSource>().Play();

            }

            //explosion
            if (explosion != null && HP <= 0)
            {
                //create explosion
                GameObject explode = Instantiate(explosion, rigidbody.position, Quaternion.identity) as GameObject;

                //delete object
                Destroy(gameObject.GetComponent<MeshCollider>());
                Destroy(gameObject.GetComponent<MeshFilter>());
                Destroy(gameObject.GetComponent<MeshRenderer>());
                Destroy(gameObject, 2);
                Destroy(explode, 2);
            }
        }

    }
}
