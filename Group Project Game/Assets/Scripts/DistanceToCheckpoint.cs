using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DistanceToCheckpoint : MonoBehaviour
{
    public string RTCPValue = "";

    // Reference to checkpoint position
    [SerializeField]
    private Transform checkpoint;
    

    //Serialization is the process of taking an object in ram (classes, fields, etc...)
    //and making a disk representation of it which can be recreated at any point in the future.



    // Calculated distance value
    private float distance; 

	
	
	// Update is called once per frame
	void Update ()
    {
        // calculate distance value between character and checkpoint
        distance = (checkpoint.transform.position - transform.position).magnitude;

        // set parameter from Wwise game parameter to scaled distance value
        AkSoundEngine.SetRTPCValue(RTCPValue, distance);

        Debug.Log(message: RTCPValue + distance);

    }
}
