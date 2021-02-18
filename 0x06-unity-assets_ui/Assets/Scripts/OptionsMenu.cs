using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private int prevScene;
    
    void start()
    {
        prevScene = SceneManager.GetActiveScene().buildIndex - 1;
    }
    public void Options()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(prevScene);
    }
}
