using UnityEngine;
using System.Collections;

public class MoveOneDirection : MonoBehaviour {

	public Vector3 direction;
	public float speed;

	void Update() {
		rigidbody.velocity = direction.normalized * speed;
	}
}
