using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Change current colour active on UI
public class ColourUI : MonoBehaviour
{
    //Image to change and the scenecontroller
    public RawImage colourImage;
    public GameObject sceneController;

    public Texture red;
    public Texture blue;
    public Texture green;
    public Texture yellow;

    //Number of colours and time between switches
    private float numberOfColours;
    private float timeBetweenSwitches;

    // Start is called before the first frame update
    void Start()
    {
        //Get values from scene controller and start cycle
        numberOfColours = sceneController.GetComponent<SceneController>().numberOfColours;
        timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
        StartCoroutine(ColourCycle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Cycle colours
    IEnumerator ColourCycle()
    {
        while (true)
        {
            //Start red
            colourImage.texture = red;
            yield return new WaitForSeconds(timeBetweenSwitches);
            //Turn blue
            colourImage.texture = blue;
            yield return new WaitForSeconds(timeBetweenSwitches);
            //Turn green if more colours
            if (numberOfColours > 2)
            {
                colourImage.texture = green;
                yield return new WaitForSeconds(timeBetweenSwitches);
                //Turn yellow if max colours
                if (numberOfColours == 4)
                {
                    colourImage.texture = yellow;
                    yield return new WaitForSeconds(timeBetweenSwitches);
                }
            }
        }
    }
}
