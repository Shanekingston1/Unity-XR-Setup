using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUIController : MonoBehaviour
{
    public GameObject gameEndContent;
    public GameManager gameManager;
    
    private void Start()
    {
        gameEndContent.gameObject.SetActive(false);
        Time.timeScale=1f;
    }

    public void OnTimerEnd()
    {
        gameManager.DisplayFinalScore();
        gameEndContent.gameObject.SetActive(true);
    }
   public void RestartButton()
   {
        SceneManager.LoadScene("MainScene");

   }

    public void MenuButton()
    {
        SceneManager.LoadScene("1 Start Scene");
    }

}
