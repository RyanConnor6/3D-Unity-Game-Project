using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pool to be used for with impact effects as to not kill FPS completely when using tons of bullets
public class ParticlePool : MonoBehaviour
{
    //Pool variables
    public static ParticlePool SharedInstance; 
    public List<GameObject> pooledObjects; 
    public GameObject objectToPool; 
    public int amountToPool; 
    
    //Shared pool
    void Awake() { 
        SharedInstance = this; 
    }
    
    //List of all objects
    void Start() 
    { 
        pooledObjects = new List<GameObject>(); 
        GameObject tmp; 
        for (int i = 0; i < amountToPool; i++) 
        { 
            tmp = Instantiate(objectToPool); 
            tmp.SetActive(false); 
            pooledObjects.Add(tmp); 
        } 
    }

    //Retrieve pooled object
    public GameObject GetPooledObject() 
    { 
        for (int i = 0; i < amountToPool; i++) 
        { 
            if (!pooledObjects[i].activeInHierarchy) 
            { 
                return pooledObjects[i]; 
            } 
        } 
        return null; 
    }
}
