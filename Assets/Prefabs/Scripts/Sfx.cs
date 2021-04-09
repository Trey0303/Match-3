using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public AudioSource match;
    public AudioSource background;

    public void PlaySfx()
    {
        match.Play();
    }

    public void PlayBackgroundMusic()
    {
        background.Play();
    }

    public void StopBackgroundMusic()
    {
        background.Stop();
    }
}
