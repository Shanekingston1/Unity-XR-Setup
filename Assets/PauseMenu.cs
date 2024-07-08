using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseContent;
    private  bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseContent.gameObject.SetActive(false);
        
    }

    private void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.X))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }

    }
    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
        //Time.timeScale = 1f;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("1 Start Scene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseContent.gameObject.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseContent.gameObject.SetActive(false);
        isPaused=false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
