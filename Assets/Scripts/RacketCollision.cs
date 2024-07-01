using UnityEngine;

public class RacketCollisionDetector : MonoBehaviour
{
    public float detectionRadius = 0.1f; // adjust to your needs
    public LayerMask ballLayer; // assign the tennis ball's layer
    public float bounceForce = 10f; // adjust the bounce force

    private void FixedUpdate()
    {
        // Create a sphere cast from the racket's position
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, ballLayer);

        // Check if any colliders were found
        foreach (Collider hit in hits)
        {
            // Check if the hit collider is the tennis ball
            if (hit.gameObject.CompareTag("TennisBall"))
            {
                // Collision detected! Handle the response
                Rigidbody ballRb = hit.gameObject.GetComponent<Rigidbody>();

                // Calculate the reflection direction
                Vector3 reflectionDirection = Vector3.Reflect(ballRb.velocity, transform.forward);

                // Apply the bounce force
                ballRb.AddForce(reflectionDirection * bounceForce, ForceMode.Impulse);

            }
        }
    }
}