using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagePlayer : MonoBehaviour
{
    public int playerHealth=80;
    int damage=5;

    public HealthBar healthBar;

    void Start()
    {
        healthBar.SetHealth(playerHealth);
    }

    void onCollisionEnter(Collision _Collision)
    {
        if (_Collision.gameObject.tag=="Enemy")
        {
            print(playerHealth);
            playerHealth-=damage;

            healthBar.SetHealth(playerHealth);
        }
        
    }
}
