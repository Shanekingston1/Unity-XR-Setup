using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int playerScore;
    public Text ScoreText;
    public Text HighScoreText;

    public void addScore()
    {
        playerScore ++;
        ScoreText.text = playerScore.ToString();
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("High Score", playerScore);
            UpdateHighScore();
        }
    }

    void UpdateHighScore()
    {
        HighScoreText.text = $"High Score:{PlayerPrefs.GetInt("High Score", 0)}";
    }
}
