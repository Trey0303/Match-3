using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sfx : MonoBehaviour
{
    public Sprite unmuteMusic;
    public Sprite muteMusic;

    public Sprite unmuteSound;
    public Sprite muteSound;

    public Button musicMuteButton;
    public Button soundMuteButton;

    public AudioSource match;
    public AudioSource background;

    public int isMuted;
    public int isSFXMuted;

    //make a seperate script for sound

    void Start()
    {
        //music
        isMuted = PlayerPrefs.GetInt("MUTE");//grabs saved settings
        if (isMuted == 1)
        {
            background.Pause();
            musicMuteButton.image.sprite = muteMusic;
        }
        else if (isMuted == 0)
        {
            background.Play();
            musicMuteButton.image.sprite = unmuteMusic;
        }

        ////sound
        isSFXMuted = PlayerPrefs.GetInt("SFX");//grabs saved settings
        if (isSFXMuted == 1)//if muted
        {
            match.volume = 0;//set volume to 0
            soundMuteButton.image.sprite = muteSound;
        }
        else if (isSFXMuted == 0)//if unmuted
        {
            match.volume = 1;//set volume to 1
            soundMuteButton.image.sprite = unmuteSound;
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

        //music
        if (isMuted == 0)//if unmuted then mute
        {
            Debug.Log("Muted");
            background.Pause();//tells to mute/pause
            isMuted = 1;//sets to muted state
            musicMuteButton.image.sprite = muteMusic;
            PlayerPrefs.SetInt("MUTE", isMuted);//saves change to settings

        }
        else if (isMuted == 1)//if muted then unmute
        {
            Debug.Log("UnMuted");
            background.Play();//tells to play/unmute
            isMuted = 0;//sets to unmuted state
            musicMuteButton.image.sprite = unmuteMusic;
            PlayerPrefs.SetInt("MUTE", isMuted);//saves change to settings

        }


    }

    public void MuteSoundPressed()
    {
        //sound
        if (isSFXMuted == 0)//if unmuted then mute
        {
            Debug.Log("Muted");
            match.volume = 0;//set volume to 0
            isSFXMuted = 1;//sets to muted state
            soundMuteButton.image.sprite = muteSound;
            PlayerPrefs.SetInt("SFX", isSFXMuted);//saves change to settings

        }
        else if (isSFXMuted == 1)//if muted then unmute
        {
            Debug.Log("UnMuted");
            match.volume = 1;//set volume to 1
            isSFXMuted = 0;//sets to unmuted state
            soundMuteButton.image.sprite = unmuteSound;
            PlayerPrefs.SetInt("SFX", isSFXMuted);//saves change to settings

        }
    }
}
