using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourNotification : MonoBehaviour
{

    public float timer =5;


    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 5;
            AkSoundEngine.PostEvent("Play_Colour_Notification_Sound", gameObject);

        }
    }
}
