using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class GameReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHandHoverBegin(Hand hand)
    {
        SceneManager.LoadScene("SampleScene");
    }

    //on click
    private void OnMouseUp()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
