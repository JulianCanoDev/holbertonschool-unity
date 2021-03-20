using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void step()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
