using UnityEngine;
using UnityEngine.SceneManagement;

public class UISTUFF2 : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject youWinMenu;
    private void OnEnable()
    {
        BattleSystem.OnPlayerDeath += EnableGameOverMenu;
        BattleSystem.OnEnemyDeath += EnableYouWinMenu;
    }

    private void OnDisable()
    {
        BattleSystem.OnPlayerDeath -= EnableGameOverMenu;
        BattleSystem.OnEnemyDeath -= EnableYouWinMenu;
    }
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
    public void EnableYouWinMenu()
    {
        youWinMenu.SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToStart()
    {
        SceneManager.LoadScene("Neighbourhood Level");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
