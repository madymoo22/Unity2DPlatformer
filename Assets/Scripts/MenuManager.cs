using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        GameManager.Instance.currentScore = 0;
        GameManager.Instance.currentHealth = 100;

        SceneManager.LoadScene("GameScene");
    }

    public void LoadHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}