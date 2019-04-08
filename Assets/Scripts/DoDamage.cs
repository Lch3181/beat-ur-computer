using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
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
        float velocity = GetComponent<Rigidbody>().velocity.magnitude;

        coll.gameObject.GetComponent<Collision>().takeDamage(velocity);
    }

}
