using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourUI2 : MonoBehaviour
{
    public Image colourImage;
    private float numberOfColours;
    private float timeBetweenSwitches;
    public GameObject sceneController;

    // Start is called before the first frame update
    void Start()
    {
        numberOfColours = sceneController.GetComponent<SceneController>().numberOfColours;
        timeBetweenSwitches = sceneController.GetComponent<SceneController>().timeBetweenSwitches;
        StartCoroutine(FirstCycle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FirstCycle()
    {
        colourImage.GetComponent<Image>().color = new Color32(24, 45, 171, 255);
        yield return new WaitForSeconds(timeBetweenSwitches);
        if (numberOfColours > 2)
        {
            colourImage.GetComponent<Image>().color = new Color32(0, 147, 12, 255);
            yield return new WaitForSeconds(timeBetweenSwitches);
            if (numberOfColours == 4)
            {
                colourImage.GetComponent<Image>().color = new Color32(219, 200, 0, 255);
                yield return new WaitForSeconds(timeBetweenSwitches);
            }
        }
        StartCoroutine(ColourCycle());
    }

    IEnumerator ColourCycle()
    {
        while (true)
        {
            colourImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(timeBetweenSwitches);
            colourImage.GetComponent<Image>().color = new Color32(24, 45, 171, 255);
            yield return new WaitForSeconds(timeBetweenSwitches);
            if (numberOfColours > 2)
            {
                colourImage.GetComponent<Image>().color = new Color32(0, 147, 12, 255);
                yield return new WaitForSeconds(timeBetweenSwitches);
                if (numberOfColours == 4)
                {
                    colourImage.GetComponent<Image>().color = new Color32(219, 200, 0, 255);
                    yield return new WaitForSeconds(timeBetweenSwitches);
                }
            }
        }
    }
}
