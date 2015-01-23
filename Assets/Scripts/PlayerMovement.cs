using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float thrustStrength = 1;
    public float thrusterDistanceFromCenter = 1;
    public float velocityDecelerationWhenBothPress = 1;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 worldForcePosition;
        // Rotate based on object rotation.
        Vector3 thrustForce = transform.rotation * Vector3.up * thrustStrength;

        if (Input.GetButton("Player1Thrust") && Input.GetButton("Player2Thrust"))
        {
            Vector3 newAngularVelocity = rigidbody.angularVelocity;
            if (Mathf.Abs(rigidbody.angularVelocity.z) > velocityDecelerationWhenBothPress * Time.deltaTime) {
                newAngularVelocity.z = rigidbody.angularVelocity.z + -Mathf.Sign(rigidbody.angularVelocity.z) * velocityDecelerationWhenBothPress * Time.deltaTime;
            }
            else {
                newAngularVelocity.z = 0;
            }
            rigidbody.angularVelocity = newAngularVelocity;
            float velocityMagnitude = rigidbody.velocity.magnitude;
            rigidbody.velocity = transform.rotation * Vector3.up * velocityMagnitude;
        }

        if (Input.GetButton("Player1Thrust"))
        {
            worldForcePosition = transform.TransformPoint(Vector3.right * thrusterDistanceFromCenter);
            rigidbody.AddForceAtPosition(thrustForce, worldForcePosition);

        }
        if (Input.GetButton("Player2Thrust"))
        {
            worldForcePosition = transform.TransformPoint(-Vector3.right * thrusterDistanceFromCenter);
            rigidbody.AddForceAtPosition(thrustForce, worldForcePosition);
        }

        // Limit speed
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
        Debug.Log(rigidbody.velocity.magnitude);
    }
}
