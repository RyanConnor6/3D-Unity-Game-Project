using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsToAppear : MonoBehaviour
{
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null)
	{
        	transform.position = new Vector3(62.59502f, 6.836533f, 1.245796f);
	}
    }
}
