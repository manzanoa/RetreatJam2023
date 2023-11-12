using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource HappySource;
    [SerializeField] AudioSource EvilSource;
    [SerializeField] Light2D globalLight;
    [SerializeField] Color happyLight;
    [SerializeField] Color evilLight;
    float timeSinceEvilLastPlayed = -20;
    float floatMinimalEvilPlayTime = 2f;

    public int peopleScared = 0;
    bool playingHappySong = true;
    public void SomeoneScared()
    {
        timeSinceEvilLastPlayed = Time.time;
        peopleScared++;
    }

    public void SomoneChill()
    {
        if (peopleScared > 0)
        {
            peopleScared--;
        }
    }

    bool camperDiedRecently =false;
    public void SomeoneDead()
    {
        timeSinceEvilLastPlayed = Time.time;
        camperDiedRecently = true;
        if (peopleScared > 0)
        {
            peopleScared--;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(peopleScared > 0 || camperDiedRecently || Time.time < timeSinceEvilLastPlayed + floatMinimalEvilPlayTime)
        {
            camperDiedRecently = false;
           // PumpMusic(EvilSource);
            //FadeMusic(HappySource);
            if (playingHappySong)
            {
                playingHappySong = false;
                globalLight.color = evilLight;
                HappySource.volume = 0;
                EvilSource.volume = 1;
            }
        }
        else
        {
            //PumpMusic(HappySource);
            //FadeMusic(EvilSource);
            if (!playingHappySong)
            {
                HappySource.Play();
                playingHappySong = true;
                globalLight.color = happyLight;
                HappySource.volume = 1;
                EvilSource.volume = 0;
            }
        }
    }

    void FadeMusic(AudioSource source)
    {
        if (source.volume > 0)
        {
            source.volume = source.volume - Time.deltaTime;
        }
    }

    void PumpMusic(AudioSource source)
    {
        if (source.volume < 1)
        {
            source.volume = source.volume + Time.deltaTime;
        }
    }
}
