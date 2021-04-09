using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public AudioSource match;

    public void PlaySfx()
    {
        match.Play();
    }
}
