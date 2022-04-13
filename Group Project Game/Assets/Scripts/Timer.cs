using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

//Class to countdown and restart level on 0
public class Timer : MonoBehaviour
{
    //Variables for TextBox and Target Time
    public TMPro.TextMeshProUGUI textbox;
    public float targetTime = 60.0f;

    //SceneController
    public GameObject SceneController;

    //Get TextBox on start
    void Start()
    {
        targetTime = SceneController.GetComponent<SceneController>().timeInLevel;
    }

    //Every tick
    void Update()
    {
        //Text changes to time remaining (rounded up)
        textbox.text = "" + Math.Ceiling(targetTime);

        //Take away elapsed time in tick
        targetTime -= Time.deltaTime;

        //Time remaining

        if (targetTime <= 60.0f && targetTime >= 59.99f)
        {
            AkSoundEngine.PostEvent("Play_1_minute_remaining", gameObject);
        }

        if (targetTime <= 30.0f && targetTime >= 29.99f)
        {
            AkSoundEngine.PostEvent("Play_30_seconds_remaining", gameObject);
        }

        //Voice countdown
        if (targetTime <= 10.0f && targetTime >= 9.99f)
        {
            AkSoundEngine.PostEvent("Play_10", gameObject);
        }


        if (targetTime <= 9.0f && targetTime >= 8.991f)
        {
            AkSoundEngine.PostEvent("Play_9", gameObject);
        }

        if (targetTime <= 8.0f && targetTime >= 7.991f)
        {
            AkSoundEngine.PostEvent("Play_8", gameObject);
        }

        if (targetTime <= 7.0f && targetTime >= 6.991f)
        {
            AkSoundEngine.PostEvent("Play_7", gameObject);
        }

        if (targetTime <= 6.0f && targetTime >= 5.991f)
        {
            AkSoundEngine.PostEvent("Play_6", gameObject);
        }

        if (targetTime <= 5.0f && targetTime >= 4.991f)
        {
            AkSoundEngine.PostEvent("Play_5", gameObject);
        }

        if (targetTime <= 4.0f && targetTime >= 3.991f)
        {
            AkSoundEngine.PostEvent("Play_4", gameObject);
        }

        if (targetTime <= 3.0f && targetTime >= 2.991f)
        {
            AkSoundEngine.PostEvent("Play_3", gameObject);
        }

        if (targetTime <= 2.0f && targetTime >= 1.991f)
        {
            AkSoundEngine.PostEvent("Play_2", gameObject);
        }

        if (targetTime <= 1.0f && targetTime >= 0.99f)
        {
            AkSoundEngine.PostEvent("Play_1", gameObject);
        }

        //If time is up, run timer end method
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }


    }

    //On timer end, reload scene
    void timerEnded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}