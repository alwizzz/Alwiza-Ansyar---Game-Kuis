using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCaller : MonoBehaviour
{
    public void PlaySFX(AudioClip clip)
    {
        AudioManager.instance.PlaySFX(clip);
    }
}
