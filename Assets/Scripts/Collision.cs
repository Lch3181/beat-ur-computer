using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Collision : MonoBehaviour
{
    public GameObject effect;
    public GameObject explosion;
    public float HP;
    private Rigidbody rb;
    private float velocity = 0;
    private Rigidbody colliRB;
    private float colliVelocity = 0;
    private float delay = 5f;

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
        if(gameObject.GetComponent<Rigidbody>())
        {
            rb = gameObject.GetComponent<Rigidbody>();
            //get velocity
            velocity = rb.velocity.magnitude;
        }

        //if luster
        if(gameObject.transform.parent && gameObject.transform.parent.name=="lusters")
        {
            if(colliRB = collision.gameObject.GetComponent<Rigidbody>())
            {
                colliVelocity = colliRB.velocity.magnitude;
            }
            if(colliVelocity > 1)
            {
                //particle system
                gameObject.GetComponentInChildren<ParticleSystem>().Play();
                //sound
                if (gameObject.GetComponentInChildren<AudioSource>() != null && delay < 0)
                {


                    gameObject.GetComponentInChildren<AudioSource>().pitch = Random.Range(.5f, 1f);
                    gameObject.GetComponentInChildren<AudioSource>().Play();

                }
            }

        }
        

        //if velocity > 1
        if (velocity > 1 && delay < 0 )
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
                Instantiate(effect, rb.position, transform.rotation);

            //particle system
            if (gameObject.GetComponentInChildren<ParticleSystem>())
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
                }
                else if(gameObject.transform.parent.name == "lusters")
                {
                    gameObject.GetComponentInChildren<ParticleSystem>().Play();
                }
            }

            //sound
            if (gameObject.GetComponentInChildren<AudioSource>() != null && delay < 0)
            {
               
                
                gameObject.GetComponentInChildren<AudioSource>().pitch = Random.Range(.5f, 1f);
                gameObject.GetComponentInChildren<AudioSource>().Play();

            }

            //explosion
            if (explosion && HP <= 0)
            {
                if(gameObject.name=="Donut(Clone)")
                {
                    //create explosion
                    GameObject explode = Instantiate(explosion, rb.position, Quaternion.identity) as GameObject;

                    //delete object
                    gameObject.GetComponent<MeshCollider>().enabled = false;
                    gameObject.GetComponent<MeshFilter>().mesh = null;
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(gameObject, 2);
                    Destroy(explode, 2);

                    GameObject Donuts = GameObject.Find("weapons/Donuts");
                    if(Donuts.GetComponent<DonutRespawn>()!=null)
                    {
                        Donuts.GetComponent<DonutRespawn>().Decrease();
                    }
                }

            }
        }
    }
}
