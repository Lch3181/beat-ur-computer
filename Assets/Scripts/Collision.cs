using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject Prefab;
    public GameObject effect;
    public GameObject explosion;
    public float HP;

    private int totalDonut = 0;
    private float delay = 1f;
    
    public void takeDamage(float amount)
    {

        HP -= amount;

        Debug.Log("HP: " + HP);
    }

    private void Update()
    {
        delay -= Time.deltaTime;

        //donut respawn
        if (gameObject.name == "Donuts")
        {
            if (transform.childCount < 2 && delay <= 0)
            {
                //get transform
                Transform transform = gameObject.GetComponent<Transform>();
                //spawn
                var newDonut = Instantiate(Prefab, transform.position, Quaternion.identity);
                newDonut.transform.parent = gameObject.transform;

                //cooldown
                delay = 5f;

                //donut count
                totalDonut++;
            }
        }

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
            HP -= velocity;
            //effect
            if (effect != null)
                Instantiate(effect, rigidbody.position, transform.rotation);

            //particle system
            if (gameObject.GetComponentInChildren<ParticleSystem>() != null)
            {
                if (gameObject.name == "Desk")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "mouse")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
<<<<<<< HEAD
=======
                else if (gameObject.name == "tower" && HP <= 50)
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    var main = gameObject.GetComponentInChildren<ParticleSystem>().main;
                    main.loop = true;
                }
>>>>>>> 056e5e38154f76d8b42c922af7f7b0db6a390437
                else if (gameObject.name == "Chair")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "Keyboard")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "DisplayScreen1" || gameObject.name == "DisplayScreen2")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
                else if (gameObject.name == "tower")
                {
                    Component[] PS = GetComponentsInChildren(typeof(ParticleSystem), true);

                    foreach (ParticleSystem joint in PS)
                    {
                        if (joint.tag == "fire")
                        {
                            joint.Play();
                        }
                        if (joint.tag == "GameController" && HP < 50)
                        {
                            joint.Play();
                        }
                    }
                }
            }

            //sound
            if (gameObject.GetComponentInChildren<AudioSource>() != null)
            {
               
                
                gameObject.GetComponentInChildren<AudioSource>().pitch = Random.Range(.5f, 1f);
                gameObject.GetComponentInChildren<AudioSource>().Play();

            }

            //explosion
            if (explosion != null && HP <= 0)
            {

                //create explosion
                GameObject explode = Instantiate(explosion, rigidbody.position, Quaternion.identity) as GameObject;

                //delete object
                gameObject.GetComponent<MeshCollider>().enabled = false;
                gameObject.GetComponent<MeshFilter>().mesh = null;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 2);
                Destroy(explode, 2);
            }
        }
    }
}
