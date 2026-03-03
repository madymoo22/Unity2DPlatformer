using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        // Note: Quit only works in built games, not in the Unity Editor
    }
}