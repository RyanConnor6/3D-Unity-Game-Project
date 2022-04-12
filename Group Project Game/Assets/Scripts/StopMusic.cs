using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    public void onClick()
    {
        AkSoundEngine.PostEvent("Stop_TitleScreenMusic", gameObject);
    }


}

