using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sfx : MonoBehaviour
{
    public InputField muteButton;
    public AudioSource match;
    public AudioSource background;

    public int isMuted;

    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTE");//grabs saved settings
        if (isMuted == 0)
        {
            background.Pause();
            PlayerPrefs.SetInt("MUTE", isMuted);
            PlayerPrefs.Save();
        }
        else if (isMuted == 1)
        {
            background.Play();
            PlayerPrefs.SetInt("MUTE", isMuted);
            PlayerPrefs.Save();
        }
    }

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

    public void MuteMusicPressed()
    {
        Debug.Log(isMuted);

        if (isMuted == 1)//if unmuted then mute
        {
            background.Pause();//tells to mute/pause
            isMuted = 0;//sets to muted state
            PlayerPrefs.SetInt("MUTE", isMuted);//saves change to settings
            
        }
        else if(isMuted == 0)//if muted then unmute
        {
            background.Play();//tells to play/unmute
            isMuted = 1;//sets to unmuted state
            PlayerPrefs.SetInt("MUTE", isMuted);//saves change to settings

        }
    }
}
