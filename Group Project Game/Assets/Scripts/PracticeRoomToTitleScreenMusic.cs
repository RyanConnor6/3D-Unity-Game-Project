using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeRoomToTitleScreenMusic : MonoBehaviour
{
    public void onClick()
    {
        AkSoundEngine.PostEvent("Room1_MusicSystem", gameObject);
    }


}
