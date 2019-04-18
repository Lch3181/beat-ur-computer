using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    private int stage = 2;
    private double delay = 0;
    Transform LoginScreen;
    Transform wallpaper;
    Transform Startup;
    Transform Shutdown;

    // Start is called before the first frame update
    void Start()
    {
        LoginScreen = gameObject.transform.Find("LoginScreen");
        wallpaper = gameObject.transform.Find("wallpaper");
        Startup = gameObject.transform.Find("WindowsXP startup");
        Shutdown = gameObject.transform.Find("WindowsXP shutdown");
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
