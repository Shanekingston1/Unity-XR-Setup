using Unity.VisualScripting;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource ballBounce;

    private void Awake() 
    {
          ballBounce = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {   
        ballBounce.Play();
    }
}
