using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public void Options()
    {
        SceneManager.LoadScene(1);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
