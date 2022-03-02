using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //Pause variables
    private bool paused = false;
    public GameObject pauseText;
    public GameObject pauseOverlay;

    // Start is called before the first frame update
    void Start()
    {
        //Pause off
        pauseText.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Get esc key pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If running pause game and show UI
            if (paused == false)
            {
                Time.timeScale = 0;
                paused = true;
                print("paused");
                pauseText.SetActive(true);
                pauseOverlay.SetActive(true);
            }
            //If not running unpause game and hide UI
            else
            {
                Time.timeScale = 1;
                paused = false;
                print("unpaused");
                pauseText.SetActive(false);
                pauseOverlay.SetActive(false);
            }
        }
    }
}
