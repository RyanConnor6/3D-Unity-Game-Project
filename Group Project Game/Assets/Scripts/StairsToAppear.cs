using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsToAppear : MonoBehaviour
{
    public GameObject SceneController;
    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        SceneController = GameObject.Find("SceneController");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneController.GetComponent<SceneController>().enemiesLeft == 0)
        {
            transform.position = new Vector3(x, y, z);
        }
    }
}