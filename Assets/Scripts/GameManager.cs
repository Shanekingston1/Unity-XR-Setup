using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int playerScore;
    public TextMeshPro ScoreText;
    public TextMeshProUGUI HighScoreText;
    private bool hasHitRacket = false;
    private bool hasHitWall = false;
    [SerializeField] private int racketLayer = 8; 
    [SerializeField] private int wallLayer = 9;   

    public void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void Start()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    private void HandleCollision(GameObject obj)
    {
        if (obj.layer == racketLayer)
        {
            hasHitRacket = true;
            hasHitWall = false; // Reset wall hit
        }
        else if (obj.layer == wallLayer)
        {
            if (hasHitRacket && !hasHitWall)
            {
                addScore();
                CheckHighScore();
                Debug.Log("Score: " + playerScore);
                hasHitWall = true; // Ensure it only scores once per valid sequence
            }
        }
        else
        {
            // Reset if it hits anything else first
            hasHitRacket = false;
            hasHitWall = false;
        }
    }
    
    public void addScore()
    {
        playerScore ++;
        ScoreText.text = playerScore.ToString();
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
        HighScoreText.text = $"H.Score:{PlayerPrefs.GetInt("High Score", 0)}";
    }
}
