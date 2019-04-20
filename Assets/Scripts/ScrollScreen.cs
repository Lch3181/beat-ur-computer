using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScreen : MonoBehaviour
{
    private double delay = 0;
    bool ScrollDown = true;
    private Vector3 pos;
    private float hideY = 8.33f;
    private float showY = 3.25f;

    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (ScrollDown && pos.y >= showY)
        {
            pos.y -= Time.deltaTime;
            gameObject.GetComponent<Transform>().position = pos;
        }
        else if (!ScrollDown && pos.y <= hideY)
        {
            pos.y += Time.deltaTime;
            gameObject.GetComponent<Transform>().position = pos;
        }
    }

    private void OnMouseUp()
    {
        Debug.Log(1);
        ScrollDown = !ScrollDown;
    }

}
