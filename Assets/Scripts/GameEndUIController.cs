using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndUIController : MonoBehaviour
{
    public GameObject content;

    private void Start()
    {
        content.gameObject.SetActive(false);
    }

    public void OnTimerEnd()
    {
        content.gameObject.SetActive(true);
    }
   public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
