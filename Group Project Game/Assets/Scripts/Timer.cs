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