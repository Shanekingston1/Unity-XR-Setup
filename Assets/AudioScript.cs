using Unity.VisualScripting;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource ballBounce;

    private void Awake() 
    {
        ballBounce = GetComponent<AudioSource>();

          if (ballBounce == null)
        {
            Debug.LogError("AudioSource component not found on " + gameObject.name);
        }
        else
        {
            Debug.Log("AudioSource component found on " + gameObject.name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        
        ballBounce.Play();
    }
}
