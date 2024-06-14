using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.layer == 8 && collision.gameObject.layer == 3)
        {
            gameManager.addScore();
        }
        
    }
}
