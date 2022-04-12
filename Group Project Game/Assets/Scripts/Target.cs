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

            if (tag == "Enemy")
            {
                AkSoundEngine.PostEvent("Play_MinionGrunts", gameObject);
            }

            if (tag == "DestroyableTargets")
            {
                AkSoundEngine.PostEvent("Play_Targets", gameObject);
            }

            if (tag == "MiniBoss")
            {
                AkSoundEngine.PostEvent("Play_Boss_Death", gameObject);
            }

            if (tag == "LastBoss")
            {
                AkSoundEngine.PostEvent("Play_Boss_Death", gameObject);
            }
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