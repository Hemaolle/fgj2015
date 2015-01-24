using UnityEngine;
using System.Collections;

public class SelfRotation : MonoBehaviour {

	public float speed = 0f;

	

	void FixedUpdate () {
		//moveRotation (Time.fixedDeltaTime, transform, speed);

		Vector3 eulerAngleVelocity = new Vector3(0, 0, speed);
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}

//	private void moveRotation(float amount, Transform target, float speed) {
//		Quaternion nextRotation_1 = target.localRotation;
//		Vector3 euler1 = nextRotation_1.eulerAngles;
//		euler1.z = euler1.z + amount * speed;
//		target.localRotation = Quaternion.Euler (euler1);
//	}
}
