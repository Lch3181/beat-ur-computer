using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision : MonoBehaviour
{
    public GameObject effect;
    public GameObject explosion;
    public float HP;

    private int totalDonut = 0;
    private float delay = 1f;
    
    public void takeDamage(float amount)
    {

        HP -= amount;

        //Debug.Log("HP: " + HP);
    }

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
            if (velocity >= 25) 
            {
                HP -= 25;
            }
            else
            {
                HP -= velocity;
            }
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
                        if (joint.tag == "spark")
                        {
                            joint.Play();
                        }
                        if (joint.tag == "smoke" && HP <= 50)
                        {
                            joint.Play();
                            var main = joint.main;
                            main.loop = true;
                        }
                    }
                }
                else if(gameObject.name=="node_id30")//Printer
                {
                    Component[] PS = GetComponentsInChildren(typeof(ParticleSystem), true);

                    foreach (ParticleSystem joint in PS)
                    {
                        if (joint.tag == "spark")
                        {
                            joint.Play();
                        }
                        if (joint.tag == "smoke" && HP <= 50)
                        {
                            joint.Play();
                            var main = joint.main;
                            main.loop = true;
                        }
                    }
                }
                else if (gameObject.name == "Projector")
                {
                    Component[] PS = GetComponentsInChildren(typeof(ParticleSystem), true);

                    foreach (ParticleSystem joint in PS)
                    {
                        if (joint.tag == "spark")
                        {
                            joint.Play();
                        }
                        if (joint.tag == "smoke" && HP <= 50)
                        {
                            joint.Play();
                            var main = joint.main;
                            main.loop = true;
                        }
                    }
                    if(HP<=50)//unlock Position
                    {
                        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    }
                }
                else if(gameObject.transform.parent.name=="lusters")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
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
                if(gameObject.name=="Donut(Clone)")
                {
                    //create explosion
                    GameObject explode = Instantiate(explosion, rigidbody.position, Quaternion.identity) as GameObject;

                    //delete object
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                    gameObject.GetComponent<MeshFilter>().mesh = null;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(gameObject, 2);
                    Destroy(explode, 2);

                    GameObject Donuts = GameObject.Find("Donuts");
                    if(Donuts.GetComponent<DonutRespawn>()!=null)
                    {
                        Donuts.GetComponent<DonutRespawn>().Decrease();
                    }
                }

            }
        }
    }
}
