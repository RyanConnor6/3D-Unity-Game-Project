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

    void Start()
    {
        //Instantiate
        health = maxHealth;
        slider.value = CalculateHealth();
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