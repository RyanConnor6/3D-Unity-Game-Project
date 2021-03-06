using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedScript : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material ActiveMaterial;
    private Renderer rend;
    public GameObject sceneController;
    private float time;
    private float numberOfColours;
    private float timeBetweenSwitches;


    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        numberOfColours = sceneController.GetComponent<SceneController>().numberOfColours;
        timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
        StartCoroutine(ColourCycle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ColourCycle()
    {
        while (true)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            rend.material = ActiveMaterial;
            yield return new WaitForSeconds(timeBetweenSwitches);

            gameObject.GetComponent<BoxCollider>().enabled = false;
            rend.material = InactiveMaterial;
            yield return new WaitForSeconds(timeBetweenSwitches);

            if (numberOfColours > 2)
            {
                yield return new WaitForSeconds(timeBetweenSwitches);
                if (numberOfColours == 4)
                {
                    yield return new WaitForSeconds(timeBetweenSwitches);
                }
            }
        }
    }
}
