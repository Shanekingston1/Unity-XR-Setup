using UnityEngine;

public class RacketCollision : MonoBehaviour
{
    public GameObject tennisBall;
    public float collisionForce = 10f;
    public float collisionThreshold = 0.1f;

    private Vector3 ballVelocity;
    private Vector3 racketVelocity;
    private float ballMass;
    private float racketMass;

    void Start()
    {
        ballMass = tennisBall.GetComponent<Rigidbody>().mass;
        racketMass = GetComponent<Rigidbody>().mass;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == tennisBall)
        {
            ballVelocity = tennisBall.GetComponent<Rigidbody>().velocity;
            racketVelocity = GetComponent<Rigidbody>().velocity;

            
            Vector3 relativeVelocity = ballVelocity - racketVelocity; // Calculating the relative velocity between the ball and racket

            // Check if the collision is valid (i.e., the ball is moving towards the racket)
            if (Vector3.Dot(relativeVelocity, transform.forward) > collisionThreshold)
            {
                // calculating impulse to apply the ball
                Vector3 impulse = CalculateImpulse(relativeVelocity, ballMass, racketMass);

                // Apply the impulse to the ball
                tennisBall.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);

                // Reposition the ball to avoid further collision detection
                tennisBall.transform.position += impulse.normalized * collisionForce;
            }
        }
    }

    Vector3 CalculateImpulse(Vector3 relativeVelocity, float ballMass, float racketMass)
    {
        // Calculate the coefficient of restitution (COR) for the collision
        float COR = 0.728f; // adjust this value to fine-tune the collision response

        // Calculate the impulse to apply to the ball
        Vector3 impulse = (1 + COR) * relativeVelocity * ballMass / (ballMass + racketMass);

        return impulse;
    }
}