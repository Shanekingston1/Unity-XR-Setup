using UnityEngine;

public class CustomCollisionDetection : MonoBehaviour
{
    public float detectionRadius = 0.3f; 
    public LayerMask ballLayer; 
    public float bounceForce = 5f; 

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, detectionRadius, ballLayer))
        {
            Debug.Log("Collision detected!");

            // Get the tennis ball's Rigidbody component
            Rigidbody ballRb = hit.transform.GetComponent<Rigidbody>();

            // Calculate the reflection direction
            Vector3 reflectionDirection = Vector3.Reflect(ballRb.velocity, transform.forward);

            // Apply the bounce force
            ballRb.AddForce(reflectionDirection * bounceForce, ForceMode.Impulse);
        }
    }
}