using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TimeToSwitch : MonoBehaviour
{
    public GameObject sceneController;
    private float timeBetweenSwitches;
    public TMPro.TextMeshProUGUI textbox;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "" + Math.Ceiling(timeBetweenSwitches);
        timeBetweenSwitches -= Time.deltaTime;
        if (timeBetweenSwitches < 0)
        {
            timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
        }
    }
}
