using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGreen : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material ActiveMaterial;
    private Renderer rend;
    public GameObject sceneController;
    private float time;
    private float numberOfColours;
    private float timeBetweenSwitches;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
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
        SetAllCollidersStatus(false);
        rend.material = InactiveMaterial;
        yield return new WaitForSeconds(timeBetweenSwitches * 2);

        SetAllCollidersStatus(true);
        rend.material = ActiveMaterial;
        yield return new WaitForSeconds(timeBetweenSwitches);
        StartCoroutine(ColourCycle());
    }

    IEnumerator ColourCycle()
    {
        while (true)
        {
            SetAllCollidersStatus(false);
            rend.material = InactiveMaterial;
            yield return new WaitForSeconds(timeBetweenSwitches);

            yield return new WaitForSeconds(timeBetweenSwitches);
            if (numberOfColours == 4)
            {
                yield return new WaitForSeconds(timeBetweenSwitches);
            }

            SetAllCollidersStatus(true);
            rend.material = ActiveMaterial;
            yield return new WaitForSeconds(timeBetweenSwitches);
        }
    }

    public void SetAllCollidersStatus(bool active)
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = active;
            Player.transform.parent = null;
        }
    }
}