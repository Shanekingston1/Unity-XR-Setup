using UnityEngine;

public class TennisBallCollision : MonoBehaviour
{
    // Assign the ball Rigidbody in the Inspector
    public Rigidbody ballRigidbody;

    // Assign the racket Rigidbody in the Inspector
    public Rigidbody racketRigidbody;

    void Start()
    {
        // Ensure continuous collision detection for both ball and racket
        if (ballRigidbody != null)
        {
            ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
        if (racketRigidbody != null)
        {
            racketRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Racket"))
        {
            // Calculate the collision impact force and direction
            Vector3 impactDirection = collision.contacts[0].normal;
            float impactForce = collision.relativeVelocity.magnitude;

            // Reflect the ball in the opposite direction of the racket's impact
            Vector3 reflectionDirection = Vector3.Reflect(ballRigidbody.velocity, impactDirection).normalized;

            // Apply force to the ball based on the impact, if the force is valid
            if (!float.IsNaN(impactForce) && !IsNaNVector(reflectionDirection))
            {
                ballRigidbody.velocity = reflectionDirection * impactForce;
            }
        }
    }

    // Helper method to check if a Vector3 contains NaN values
    bool IsNaNVector(Vector3 vector)
    {
        return float.IsNaN(vector.x) || float.IsNaN(vector.y) || float.IsNaN(vector.z);
    }
}
