using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockExitScript : MonoBehaviour
{
    public GameObject SceneController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneController.GetComponent<SceneController>().enemiesLeft == 0)
        {
            Destroy(gameObject);
        }
    }
}
