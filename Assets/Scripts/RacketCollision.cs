using UnityEngine;

public class RacketCollision : MonoBehaviour
{
    public float sphereRadius = 0.5f; 
    public LayerMask ballLayer; 
    public float collisionForce; 

    private bool hasCollided = false;

    void Start()
    {
        // Set collision detection mode for the ball
        GameObject ball = GameObject.FindGameObjectWithTag("TennisBall");
        if (ball != null)
        {
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }
        }
    }

    void FixedUpdate()
    {
        if (!hasCollided)
        {
            // Position of the racket
            Vector3 racketPosition = transform.position;

            // Check for collisions
            Collider[] hitColliders = Physics.OverlapSphere(racketPosition, sphereRadius, ballLayer);

            foreach (var hitCollider in hitColliders)
            {
                // If a collision with the ball is detected
                if (hitCollider.CompareTag("TennisBall"))
                {
                    // Handle the collision (e.g., apply force to the ball)
                    Rigidbody ballRigidbody = hitCollider.GetComponent<Rigidbody>();
                    if (ballRigidbody != null)
                    {
                        Vector3 forceDirection = (hitCollider.transform.position - racketPosition).normalized;
                        ballRigidbody.AddForce(forceDirection * collisionForce); // Adjust force as needed
                        hasCollided = true;
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Draw the overlap sphere in the editor for debugging purposes
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("TennisBall"))
        {
            hasCollided = false; // Reset flag when the ball exits the collision
        }
    }
}
