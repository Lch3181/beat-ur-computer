using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutRespawn : MonoBehaviour
{

    public GameObject gameObject;
    public GameObject Prefab;
    private int totalDonut = 0;
    private float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
