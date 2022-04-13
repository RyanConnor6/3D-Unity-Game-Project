using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicStopAfterDeath : MonoBehaviour
{
    // Variable to control the player object
    public GameObject player;

    //Reset level
    public void OnTriggerEnter(Collider other)
    {
        if (tag == "Player")
        {
            AkSoundEngine.PostEvent("Stop_Room1_MusicSystem", gameObject);


        }
    }
}
