using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth=80;
    int damage=5;

    public HealthBar healthBar;

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
            print(playerHealth);
            playerHealth -= damage;

            healthBar.SetHealth(playerHealth);
        }
    }
}
