using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Sfx BackgroundMusic;

    public bool musicOn = true;

    public int time = 10;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundMusic = GameObject.Find("Sound").GetComponent<Sfx>();
        BackgroundMusic.PlayBackgroundMusic();
        time = 10;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (time == 0)
        {

            BackgroundMusic.StopBackgroundMusic();
            musicOn = false;
        }
        if (time == 11)
        {
            BackgroundMusic.PlayBackgroundMusic();
            musicOn = true;
        }
        if (count == 100)
        {
            if (musicOn)
            {
                count = 0;
                time--;
            }
            else if (!musicOn)
            {
                count = 0;
                time++;
            }

        }
    }
}
