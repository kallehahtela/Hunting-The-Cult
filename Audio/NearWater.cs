using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearWater : MonoBehaviour
{
    AudioSource source;
    Collider soundTrigger;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
    }



    public void OnTriggerEnter(Collider col) 
    {
        if (col.CompareTag("Player"))
        {
            source.Play();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            source.Stop();
        }
    }
}
