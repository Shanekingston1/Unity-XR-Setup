using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUIController : MonoBehaviour
{
    public GameObject gameEndContent;
    
    public bool isPaused;

    private void Start()
    {
        gameEndContent.gameObject.SetActive(false);
        
    }


    public void OnTimerEnd()
    {
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
