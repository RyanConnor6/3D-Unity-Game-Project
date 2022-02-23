using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeToSwitch : MonoBehaviour
{
    //Colour switch time variables
    public GameObject sceneController;
    private float timeBetweenSwitches;
    public TMPro.TextMeshProUGUI textbox;

    // Start is called before the first frame update
    void Start()
    {
        //Get time between from scenecontroller
        timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
    }

    // Update is called once per frame
    void Update()
    {
        //Add time left to textbox
        textbox.text = "" + Math.Ceiling(timeBetweenSwitches);
        timeBetweenSwitches -= Time.deltaTime;
        //If time up, reset timer
        if (timeBetweenSwitches < 0)
        {
            timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
        }
    }
}
