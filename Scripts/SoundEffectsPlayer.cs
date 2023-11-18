using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource Button_Bite_SFX;
    public AudioClip sfx1;

    public void Button1()
    {
        Button_Bite_SFX.clip = sfx1;
        Button_Bite_SFX.Play();
    }
}
