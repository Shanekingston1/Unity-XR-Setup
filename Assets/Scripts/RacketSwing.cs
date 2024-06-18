using UnityEngine;

public class RacketSwing : MonoBehaviour
{ public AudioClip swooshSound;
    private AudioSource audioSource;
    private Vector3 lastPosition;
    private Quaternion lastRotation;
    private float swingThreshold = 2.0f; // Velocity threshold
    private float rotationThreshold = 45.0f; // Rotation threshold in degrees

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = swooshSound;
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void Update()
    {
        DetectSwing();
    }

    void DetectSwing()
    {
        // Calculates the speed and rotational change
        float speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        float angularSpeed = Quaternion.Angle(lastRotation, transform.rotation) / Time.deltaTime;

        if (speed > swingThreshold && angularSpeed > rotationThreshold)
        {
            PlaySwooshSound();
        }

        // Updates the last position and rotation
        lastPosition = transform.position;
        lastRotation = transform.rotation;
    }

    void PlaySwooshSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
