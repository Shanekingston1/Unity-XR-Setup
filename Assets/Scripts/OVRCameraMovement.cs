using UnityEngine;

public class OVRCameraMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 90.0f;
    // Update is called once per frame
    void Update()
    {
         Vector3 direction = Vector3.zero;

        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            direction += Vector3.forward;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown))
        {
            direction += Vector3.back;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft))
        {
            direction += Vector3.left;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
        {
            direction += Vector3.right;
        }

        direction *= speed * Time.deltaTime;
        transform.Translate(direction);

         // Handle continuous rotation
        Vector2 primaryThumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        float rotationAmount = primaryThumbstick.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);

    }
}
