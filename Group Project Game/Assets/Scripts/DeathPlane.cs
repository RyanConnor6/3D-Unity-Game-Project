using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    // Variable to control the player object
    public GameObject player;

    //Reset level
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            AkSoundEngine.PostEvent("Play_Character_Death", gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}