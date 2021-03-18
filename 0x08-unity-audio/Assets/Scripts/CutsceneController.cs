using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Player;
    public GameObject TimerCanvas;
    void camTransition()
    {
        MainCamera.SetActive(true);
        TimerCanvas.SetActive(true);
        Player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }
}
