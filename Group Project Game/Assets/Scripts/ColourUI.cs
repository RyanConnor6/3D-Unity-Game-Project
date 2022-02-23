using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Change current colour active on UI
public class ColourUI : MonoBehaviour
{
    //Image to change and the scenecontroller
    public Image colourImage;
    public GameObject sceneController;

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
            colourImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(timeBetweenSwitches);
            //Turn blue
            colourImage.GetComponent<Image>().color = new Color32(24, 45, 171, 255);
            yield return new WaitForSeconds(timeBetweenSwitches);
            //Turn green if more colours
            if (numberOfColours > 2)
            {
                colourImage.GetComponent<Image>().color = new Color32(0, 147, 12, 255);
                yield return new WaitForSeconds(timeBetweenSwitches);
                //Turn yellow if max colours
                if (numberOfColours == 4)
                {
                    colourImage.GetComponent<Image>().color = new Color32(219, 200, 0, 255);
                    yield return new WaitForSeconds(timeBetweenSwitches);
                }
            }
        }
    }
}
