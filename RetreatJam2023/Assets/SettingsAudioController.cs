using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsAudioController : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    public void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }

    public void Mute(bool mute)
    {
        audioSource.mute = mute;
    }
}
