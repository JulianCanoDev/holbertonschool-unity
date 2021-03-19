using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSteps : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void step()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
