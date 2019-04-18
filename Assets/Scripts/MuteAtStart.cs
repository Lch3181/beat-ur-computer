using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAtStart : MonoBehaviour
{
    private double delay = 5;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = true;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            AudioListener.pause = false;
        }
    }
}
