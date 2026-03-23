using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int currentScore = 0;
    public int currentHealth = 100;

    public delegate void ScoreChanged(int newScore);
    public delegate void HealthChanged(int newHealth);
    public delegate void GameOver();

    public static event ScoreChanged OnScoreChanged;
    public static event HealthChanged OnHealthChanged;
    public static event GameOver OnGameOver;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (OnScoreChanged != null)
        {
            OnScoreChanged(currentScore);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (OnHealthChanged != null)
        {
            OnHealthChanged(currentHealth);
        }

        if (currentHealth <= 0)
        {
            TriggerGameOver();
        }
    }

    public void TriggerGameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public void RestartGame()
    {
        if (CoinPoolManager.Instance != null)
        {
            CoinPoolManager.Instance.ResetAllCoins();
        }

        currentScore = 0;
        currentHealth = 100;

        SceneManager.LoadScene("GameScene");
    }
}