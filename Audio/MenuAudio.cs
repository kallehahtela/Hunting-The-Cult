using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    public AudioSource birdsAudio;
    public AudioSource waterAudio;

    void Awake()
    {
        birdsAudio.Play();
        waterAudio.Play();
    }
}
