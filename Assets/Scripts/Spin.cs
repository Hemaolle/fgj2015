using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {

    public float angularVelocity = 1;
	
    void Start() {
        rigidbody.angularVelocity = new Vector3(0, 0, angularVelocity);
    }
}
