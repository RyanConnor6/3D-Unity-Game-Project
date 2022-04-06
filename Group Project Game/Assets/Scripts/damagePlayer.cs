using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth=100;
    int damage=5;

    public int playerArmour = 50;

    public HealthBar healthBar;
    public ArmourBar armourBar;

    void Start()
    {
        healthBar.SetHealth(playerHealth);
    }

    void Update()
    {
        if (playerHealth < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.gameObject.tag == "Enemy")
        {
            if (playerArmour > 0)
            {
                print(playerArmour);
                playerArmour -= damage;

                armourBar.SetArmour(playerArmour);
            }
            else
            {
                print(playerHealth);
                playerHealth -= damage;

                healthBar.SetHealth(playerHealth);
            }
            
        }
    }
}
