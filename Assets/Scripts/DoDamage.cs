using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public float damageAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision coll)
    {
        float velocity = 0;

        if (GetComponent<Rigidbody>()!=null)
            velocity = GetComponent<Rigidbody>().velocity.magnitude;

        if(coll.gameObject.GetComponent<Collision>() != null)
        {
            coll.gameObject.GetComponent<Collision>().takeDamage(velocity);
            coll.gameObject.GetComponent<Collision>().takeDamage(damageAmount);
        }
            
    }

}
