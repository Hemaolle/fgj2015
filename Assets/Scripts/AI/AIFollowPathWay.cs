using UnityEngine;
using System.Collections;

public class AIFollowPathWay : MonoBehaviour {

	public Rigidbody ownRigidbody;

	public bool IsEnabled = true;
	public Vector3[] waypoints = new Vector3[] { Vector3.zero };
	public Transform[] waypointTransforms;
	public float speed = 4f;

	public float deadZoneDistance = 0.1f;

	private int _CurrentIndex = 0;

	void Start () {
		if (waypointTransforms.Length > 0) {
			waypoints = new Vector3[waypointTransforms.Length];
			for (int i=0; i<waypoints.Length; i++) {
				waypoints[i] = waypointTransforms[i].position;
			}
		}

		if (!ownRigidbody) {
			ownRigidbody = rigidbody;
		}
	}
	

	void Update () {
		if (IsEnabled) {

		}
	}

	void FixedUpdate () {
		if (IsEnabled) {
			if ((transform.position - waypoints[_CurrentIndex]).magnitude > deadZoneDistance) {
				ownRigidbody.velocity = (waypoints[_CurrentIndex] - transform.position).normalized * speed;
				ownRigidbody.transform.LookAt(waypoints[_CurrentIndex]);
			} else {
				_CurrentIndex = (_CurrentIndex + 1) % waypoints.Length;
			}
		}
	}
}
