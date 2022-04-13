using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonoSoundTrigger : MonoBehaviour
{
    // Variable to control the player object
    public GameObject player;
    private bool hasPlayed = false;

    //Reset level
    public void OnTriggerEnter(Collider other)
    {
        if (tag == "Player")
        {
            if (!hasPlayed)
            {
                AkSoundEngine.PostEvent("Play_Room1_MusicSystem", gameObject);
                hasPlayed = true;
            }

        }
    }
}
