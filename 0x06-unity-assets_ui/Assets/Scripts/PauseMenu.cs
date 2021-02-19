using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PauseMenuIU;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void Resume()
    {
        PauseMenuIU.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        PauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
