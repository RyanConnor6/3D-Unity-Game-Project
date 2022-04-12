using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic_Event : MonoBehaviour
{
    public void onClick()
    {
        AkSoundEngine.PostEvent("Room1_MusicSystem", gameObject);
    }


}
