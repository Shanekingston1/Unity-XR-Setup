using UnityEngine;

public class RacketCollision : MonoBehaviour
{
    public GameObject Tennisball;
    public float collisionForce = 10f;
    public float collisionThreshold = 0.1f;

    private Vector3 ballVelocity;
    private Vector3 racketVelocity;
    private float ballMass;
    private float racketMass;

    void Start()
    {
        ballMass = Tennisball.GetComponent<Rigidbody>().mass;
        racketMass = GetComponent<Rigidbody>().mass;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Tennisball)
        {
            ballVelocity = Tennisball.GetComponent<Rigidbody>().velocity;
            racketVelocity = GetComponent<Rigidbody>().velocity;

            // Calculate the relative velocity between the ball and racket
            Vector3 relativeVelocity = ballVelocity - racketVelocity;

            // Check if the collision is valid (i.e., the ball is moving towards the racket)
            if (Vector3.Dot(relativeVelocity, transform.forward) > collisionThreshold)
            {
                // Calculate the impulse to apply to the ball
                Vector3 impulse = CalculateImpulse(relativeVelocity, ballMass, racketMass);

                // Apply the impulse to the ball
                Tennisball.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);

                // Reposition the ball to avoid further collision detection
                Tennisball.transform.position += impulse.normalized * collisionForce;
            }
        }
    }

    Vector3 CalculateImpulse(Vector3 relativeVelocity, float ballMass, float racketMass)
    {
        // Calculate the coefficient of restitution (COR) for the collision
        float COR = 0.7f; // adjust this value to fine-tune the collision response

        // Calculate the impulse to apply to the ball
        Vector3 impulse = (1 + COR) * relativeVelocity * ballMass / (ballMass + racketMass);

        return impulse;
    }
}