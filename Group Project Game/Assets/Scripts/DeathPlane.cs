using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    // Variable to control the spawn point
    public Transform spawnPoint;
    // Variable to control the player object
    public GameObject player;

    public void OnTriggerEnter(Collider player)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}