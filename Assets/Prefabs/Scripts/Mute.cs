using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public bool isMuted;

    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    public void MuteMusicPressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.GetInt("MUTED", isMuted ? 1 : 0);


        //if (isMuted)
        //{
        //    background.Pause();
        //}
        //else
        //{
        //    background.Play();
        //}
    }
}
