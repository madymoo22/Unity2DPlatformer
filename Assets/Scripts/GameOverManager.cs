using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_InputField playerNameInput;

    void Start()
    {
        finalScoreText.text = "Final Score: " + GameManager.Instance.currentScore;
    }

    public void TryAgain()
    {
        SaveScore();
        GameManager.Instance.RestartGame();
    }

    public void BackToMenu()
    {
        SaveScore();
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveScore()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        int score = GameManager.Instance.currentScore;
        float time = Time.timeSinceLevelLoad;

        DatabaseManager.Instance.SaveHighScore(playerName, score, time);
    }
}