using UnityEngine;
using UnityEngine.SceneManagement;

public class UISTUFF : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Health.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    { 
        gameOverMenu.SetActive(true); 
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
