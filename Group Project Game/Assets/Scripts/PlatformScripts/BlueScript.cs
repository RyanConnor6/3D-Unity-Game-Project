using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScript : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public Renderer rend;
    public GameObject timer;
    public float time;
    public float numberOfColours;
    public float timeBetweenSwitches;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(FirstCycle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FirstCycle()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        rend.material = material1;
        yield return new WaitForSeconds(timeBetweenSwitches);

        gameObject.GetComponent<BoxCollider>().enabled = true;
        rend.material = material2;
        yield return new WaitForSeconds(timeBetweenSwitches);
        StartCoroutine(ColourCycle());
    }

    IEnumerator ColourCycle()
    {
        while (true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rend.material = material1;
            yield return new WaitForSeconds(timeBetweenSwitches);

            if (numberOfColours > 2)
            {
                yield return new WaitForSeconds(timeBetweenSwitches);
                if (numberOfColours == 4)
                {
                    yield return new WaitForSeconds(timeBetweenSwitches);
                }
            }

            gameObject.GetComponent<BoxCollider>().enabled = true;
            rend.material = material2;
            yield return new WaitForSeconds(timeBetweenSwitches);
        }
    }
}