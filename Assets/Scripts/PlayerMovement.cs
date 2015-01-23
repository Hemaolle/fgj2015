using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float forceStrength = 1;
    public float thrusterDistanceFromCenter = 1;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 worldForcePosition;
        // Rotate based on object rotation.
        Vector3 thrustForce = transform.rotation * Vector3.up * forceStrength;

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
    }
}
