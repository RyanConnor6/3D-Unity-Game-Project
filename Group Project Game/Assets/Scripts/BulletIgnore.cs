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

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy bullet on collision
        Destroy(gameObject);
    }
}
