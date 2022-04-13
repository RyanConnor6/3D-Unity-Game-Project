using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        AkSoundEngine.PostEvent("Stop_Room1_MusicSystem", gameObject);
        SceneManager.LoadScene(sceneToLoad);
    }
}
