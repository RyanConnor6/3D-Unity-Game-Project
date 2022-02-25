using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    //Health and max health
    public float health = 50f;
    public float maxHealth = 50f;

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