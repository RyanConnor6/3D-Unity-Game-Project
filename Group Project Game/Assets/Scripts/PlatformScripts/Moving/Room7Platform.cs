using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room7Platform : MonoBehaviour
{
    public GameObject Player;
    public GameObject Attatch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
            Player.transform.parent = Attatch.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
