using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEvent : MonoBehaviour
{
    public AK.Wwise.Event sound;
    bool isSoundPlaying;
    void Start()
    {
        sound.Post(gameObject, (uint)AkCallbackType.AK_EndOfEvent, CallBackFunction);
        isSoundPlaying = true;
    }
    void CallBackFunction(object in_cookie, AkCallbackType callType, object in_info)
    {
        if (callType == AkCallbackType.AK_EndOfEvent)
        {
            isSoundPlaying = false;
        }
    }
    void PlayOtherSound()
    {
        if (!isSoundPlaying)
        {
            AkSoundEngine.PostEvent("Stop_Room1_MusicSystem", gameObject);
        }
    }
}

