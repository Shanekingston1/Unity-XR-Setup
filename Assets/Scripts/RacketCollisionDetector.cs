using UnityEngine;

public class RacketCollisionDetector : MonoBehaviour
{
    public float detectionRadius;
    public LayerMask ballLayer; 
    public float bounceForce; 

    private void FixedUpdate()
    {
        
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius, ballLayer);
        
        foreach (Collider hit in hits)
        {
            
            if (hit.gameObject.CompareTag("TennisBall"))
            {                
                Rigidbody ballRb = hit.gameObject.GetComponent<Rigidbody>();
                
                Vector3 reflectionDirection = Vector3.Reflect(ballRb.velocity, transform.forward);
               
                ballRb.AddForce(reflectionDirection * bounceForce);   
            }
        }
    }
}