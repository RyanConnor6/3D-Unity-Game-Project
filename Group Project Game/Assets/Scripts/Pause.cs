using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseText;
    public GameObject pauseOverlay;

    // Start is called before the first frame update
    void Start()
    {
        pauseText.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                Time.timeScale = 0;
                paused = true;
                print("paused");
                pauseText.SetActive(true);
                pauseOverlay.SetActive(true);
            }
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
