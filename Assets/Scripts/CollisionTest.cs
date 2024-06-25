using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("TennisBall"))
        {
            Debug.Log("Hit TennisBall");
            other.gameObject.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere*20f);
        }
    }
    
}
