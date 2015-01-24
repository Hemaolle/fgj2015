using UnityEngine;
using System.Collections;

public class AIShootAtTarget : MonoBehaviour {

	public GameObject bulletPrefab;
	public float bulletSpeed = 10f;
	public float fireRate = 4f;
	public Transform gunPoint;

	public GameObject target;
	public UnityLayer targetLayer;

	public AIFollowPathWay followPathAI;
	public float detectionRadius = 1f;

	private float _timer;

	void Start() {

	}

	void Update() {


		if (target) {
			if (_timer > 1f / fireRate) {
				Vector3 direction = target.transform.position - gunPoint.position;
				shoot(bulletPrefab, gunPoint, direction);
				_timer = 0f;
			}
		}

		_timer += Time.deltaTime;
	}

	void FixedUpdate() {
		Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, 1 << targetLayer.layer);
		
		foreach (Collider c in colliders) {
			target = c.gameObject;
		}
	}


	private void shoot(GameObject bulletPrefab, Transform gunPoint, Vector3 direction) {
		print (gunPoint.InverseTransformDirection (Vector3.forward));
		GameObject o = (GameObject) Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
		o.rigidbody.AddForce(direction.normalized * bulletSpeed, ForceMode.Force);
	}
	
}
