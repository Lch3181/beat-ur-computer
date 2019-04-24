using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.InteractionSystem;

public class PlayVideo : MonoBehaviour
{
    public int stage = 2;
    private double delay = 0;
    private Random random = new Random();
    Transform LoginScreen;
    Transform wallpaper;
    Transform ErrorScreen;
    Transform Startup;
    Transform Shutdown;
    Transform BlueScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject screen = GameObject.FindWithTag("Screen");

        LoginScreen = screen.transform.Find("LoginScreen");
        wallpaper = screen.transform.Find("wallpaper");
        ErrorScreen = screen.transform.Find("GreenScreenError");
        Startup = screen.transform.Find("WindowsXP startup");
        Shutdown = screen.transform.Find("WindowsXP shutdown");
        BlueScreen = screen.transform.Find("BlueScreen");

    }


    void OnHandHoverBegin(Hand hand)
    {
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;

        //switch to login page after startup
        if(delay<=0 && Startup.gameObject.activeSelf && !Startup.gameObject.GetComponent<VideoPlayer>().isPlaying)
        {
            Startup.gameObject.SetActive(false);
            LoginScreen.gameObject.SetActive(true);
            stage = 2;
        }
        //Green screen error loop after login at a random time and disable shutdown
        if(delay<=0 && wallpaper.gameObject.activeSelf && !ErrorScreen.gameObject.activeSelf)
        {
            wallpaper.gameObject.SetActive(false);
            ErrorScreen.gameObject.SetActive(true);
            delay = 4.5f;
            stage = -1;
        }
        //blue screen after green screen is done
        if(delay <= 0 && ErrorScreen.gameObject.activeSelf && !ErrorScreen.gameObject.GetComponent<VideoPlayer>().isPlaying)
        {
            ErrorScreen.gameObject.SetActive(false);
            BlueScreen.gameObject.SetActive(true);
        }
        //reset stage after shutdown
        if(delay <= 0 && Shutdown.gameObject.activeSelf && !Shutdown.gameObject.GetComponent<VideoPlayer>().isPlaying)
        {
            Shutdown.gameObject.SetActive(false);
            stage = 0;
        }
    }

    private void OnMouseUp()
    {
        Play();
    }

    public void Play()
    {

        switch(stage)
        {
            case 0://startup pc
                if(delay<=0 && !Startup.gameObject.activeSelf)
                {
                    Startup.gameObject.SetActive(true);
                    delay = 5;
                }

                break;
            case 1://display login page
                Startup.gameObject.SetActive(false);
                LoginScreen.gameObject.SetActive(true);
                break;
            case 2://display wallpaper
                LoginScreen.gameObject.SetActive(false);
                wallpaper.gameObject.SetActive(true);
                delay = Random.Range(3f, 8f);
                stage++;
                break;
            case 3://shutdown
                if(!Shutdown.gameObject.activeSelf)
                {
                    wallpaper.gameObject.SetActive(false);
                    Shutdown.gameObject.SetActive(true);
                    delay = 5;
                    stage++;
                }
                break;
            default:
                break;
        }
        //next stage

    }
}
