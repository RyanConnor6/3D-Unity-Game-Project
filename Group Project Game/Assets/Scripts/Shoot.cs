using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    //Bullet object & speed
    public Rigidbody projectile;
    public float speed = 20;

    // Update is called once per frame
    void Update()
    {
        //If mouse click, shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }
    }
}