using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text timerText;
    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private Text WinScore;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        timerText = GameObject.Find("TimerCanvas").transform.Find("TimerText").GetComponent<Text>();
    }

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Timer>().enabled = false;
        timerText.color = Color.green;
        timerText.fontSize = 60;
        WinScore.text = timerText.text;
        WinCanvas.SetActive(true);
        audioSource.PlayOneShot(audioClip);
    }
}
