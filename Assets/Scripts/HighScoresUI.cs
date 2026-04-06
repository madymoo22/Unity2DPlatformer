using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighScoresUI : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;

    void Start()
    {
        DisplayScores();
    }

    void DisplayScores()
    {
        List<HighScore> scores = DatabaseManager.Instance.GetTopHighScores(5);

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scores.Count)
            {
                HighScore s = scores[i];
                scoreTexts[i].text = (i + 1) + ". " + s.PlayerName + 
                                     " - " + s.Score + 
                                     " pts - " + s.CompletionTime + "s";
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ". ---";
            }
        }
    }
}