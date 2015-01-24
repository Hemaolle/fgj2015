using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float thrustStrength = 1;
    public float thrusterDistanceFromCenter = 1;
    public float velocityDecelerationWhenBothPress = 1;
    public ParticleSystem thrusterEffect1;
    public ParticleSystem thrusterEffect2;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 worldForcePosition;
        // Rotate based on object rotation.
        Vector3 thrustForce = transform.TransformDirection(Vector3.up) * thrustStrength;

        bool p1Thrusting = Input.GetButton("Player1Thrust");
        bool p2Thrusting = Input.GetButton("Player2Thrust");

        HandleThrusting(Vector3.right * thrusterDistanceFromCenter, thrustForce, p1Thrusting, thrusterEffect1);
        HandleThrusting(-Vector3.right * thrusterDistanceFromCenter, thrustForce, p2Thrusting, thrusterEffect2);

        // Limit speed
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }

    /// <summary>
    /// Applies the thrust force and turns the thruster particle effect on and off.
    /// </summary>
    /// <param name="relativeThrustPosition">Thrust position relative to the ship center.</param>
    /// <param name="thrustForce">Thrust force.</param>
    /// <param name="thrustOn">If set to <c>true</c> apply thrust and keep particle effect playing. Otherwise no thrust and stop the 
    ///             effect</param>
    /// <param name="thrusterEffect">Thruster effect.</param>
    void HandleThrusting(Vector3 relativeThrustPosition, Vector3 thrustForce, bool thrustOn, ParticleSystem thrusterEffect)
    {
        if (thrustOn)
        {
            Vector3 worldForcePosition = transform.TransformPoint(relativeThrustPosition);
            rigidbody.AddForceAtPosition(thrustForce, worldForcePosition);
            if (!thrusterEffect.isPlaying)
                thrusterEffect.Play();
        }
        else
        {
            if (thrusterEffect.isPlaying)
                thrusterEffect.Stop();
        }
    }
}
