using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Street Level");
    }
    
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
