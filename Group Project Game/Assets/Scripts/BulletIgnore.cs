using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code to destroy bullet when collision occurs
public class BulletIgnore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Collision Detected");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
