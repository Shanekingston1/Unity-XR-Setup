using UnityEngine;

public class VRSquashPhysics : MonoBehaviour
{
    public GameObject Racket1; 
    public GameObject TennisBall1;   

    public float bounceFactor = 1.0f; // Multiplier for the bounce reflection

    private Rigidbody ballRigidbody;
    private Rigidbody racketRigidbody;

    

    void Start()
    {
        // Initialize Rigidbody components
        ballRigidbody = TennisBall1.GetComponent<Rigidbody>();
        racketRigidbody = Racket1.GetComponent<Rigidbody>();

        // Set collision detection mode
        ballRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        // Make the racket kinematic to control it manually
        racketRigidbody.isKinematic = true;

        // Optionally set up physics materials
        SetupPhysicsMaterials();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Handle collision between the ball and the racket
        if (collision.gameObject == Racket1)
        {
            Debug.Log("hit");
            Vector3 reflection = Vector3.Reflect(ballRigidbody.velocity, collision.contacts[0].normal);
            ballRigidbody.velocity = reflection * bounceFactor;

            Debug.Log("Ball Velocity: " + ballRigidbody.velocity);
            Debug.Log("Collision Normal: " + collision.contacts[0].normal);
        }
    }

    void SetupPhysicsMaterials()
    {
        // Create and assign a physics material for the ball
        PhysicMaterial ballMaterial = new PhysicMaterial
        {
            bounciness = 1f,
            frictionCombine = PhysicMaterialCombine.Minimum,
            bounceCombine = PhysicMaterialCombine.Maximum
        };
        TennisBall1.GetComponent<SphereCollider>().material = ballMaterial;

        // Create and assign a physics material for the racket
        PhysicMaterial racketMaterial = new PhysicMaterial
        {
            bounciness = 1f,
            frictionCombine = PhysicMaterialCombine.Minimum,
            bounceCombine = PhysicMaterialCombine.Average
        };
        Racket1.GetComponent<Collider>().material = racketMaterial;
    }

    void OnDrawGizmos()
    {
        // Visualize ball collider in the editor
        if (TennisBall1 != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(TennisBall1.transform.position, TennisBall1.GetComponent<SphereCollider>().radius);
        }
    }
}
