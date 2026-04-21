using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Prelude");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


