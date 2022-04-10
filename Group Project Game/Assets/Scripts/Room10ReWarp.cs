using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room10ReWarp : MonoBehaviour
{
    //Health and max health
    public float health = 50f;
    public float maxHealth = 50f;

    // Player stuff
    public GameObject player;
    public float x;
    public float y;
    public float z;

    //UI elements
    public GameObject healthBarUI;
    public Slider slider;

    //SceneController
    public GameObject SceneController;

    void Start()
    {
        //Instantiate
        health = maxHealth;
        slider.value = CalculateHealth();
        SceneController = GameObject.Find("SceneController");
    }

    void Update()
    {
        //Correct slider value
        slider.value = CalculateHealth();

        //Keep UI active
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }

        //Destroy when no health
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneController.GetComponent<SceneController>().enemiesLeft--;
            player.transform.position = new Vector3(x, y, z);

        }
    }

    //Take damage from bullet
    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    //Get health for slider
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}