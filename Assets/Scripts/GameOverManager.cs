using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;

    void Start()
    {
        finalScoreText.text = "Final Score: " + GameManager.Instance.currentScore;
    }

    public void TryAgain()
    {
        GameManager.Instance.RestartGame();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}