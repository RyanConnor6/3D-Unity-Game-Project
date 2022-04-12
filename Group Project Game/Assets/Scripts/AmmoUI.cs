using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    //Variables for TextBox
    public TMPro.TextMeshProUGUI textbox;
    private float bullets = 0f;

    //SceneController
    public GameObject Gun;

    void Start()
    {
        bullets = Gun.GetComponent<Gun>().bullets;
    }

    //Every tick
    void Update()
    {
        bullets = Gun.GetComponent<Gun>().bullets;
        textbox.text = ""+bullets;
    }
}