﻿using UnityEngine;
using System.Collections;

public class PlayerShoot3 : MonoBehaviour {

	public GameObject bulletPrefab1;
	public GameObject bulletPrefab2;

	public Transform gunPoint1;
	public Transform gunPoint2;

	public float bulletSpeed = 10f;

	public float fireRate1 = 1f;
	public float fireRate2 = 1f;

	public float maxFireRate1 = 3f;
	public float maxFireRate2 = 3f;

	private float _timer1 = 0f;
	private float _timer2 = 0f;

	public float minRotationZ_1 = 0;
	public float maxRotationZ_1 = 60;
	public float minRotationZ_2 = 270;
	public float maxRotationZ_2 = 330;

	public float rotateSpeed1 = 1f;
	public float rotateSpeed2 = 2f;

	public bool IsFireRate1PoweredUp = false;
	public bool IsFireRate2PoweredUp = false;


	void Update() {
		//if (Input.GetAxis ("Player1Shoot") > 0) {
			if (_timer1 > 1f / ((IsFireRate1PoweredUp) ? maxFireRate1 : fireRate1)) {
				shoot(bulletPrefab1, gunPoint1);
				_timer1 = 0f;
			}

		//}

		moveAim (-Input.GetAxis("AimMove1"), gunPoint1, rotateSpeed1, minRotationZ_1, maxRotationZ_1);


		//if (Input.GetAxis ("Player2Shoot") > 0) {
			if (_timer2 > 1f /  ((IsFireRate2PoweredUp) ? maxFireRate2 : fireRate2)) {
				shoot(bulletPrefab2, gunPoint2);
				_timer2 = 0f;
			}
		//}

		moveAim (Input.GetAxis("AimMove2"), gunPoint2, rotateSpeed2, minRotationZ_2, maxRotationZ_2);

		_timer1 += Time.deltaTime;
		_timer2 += Time.deltaTime;	
	}

	private void shoot(GameObject bulletPrefab, Transform gunPoint) {
		GameObject o = (GameObject) Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
		o.rigidbody.AddForce(gunPoint.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Force);
		
		// "Look at" the next waypoint
		var relativeUp = Vector3.forward;
		var relativePos = gunPoint.position + gunPoint.TransformDirection (Vector3.up);
		o.transform.rotation = Quaternion.LookRotation(relativeUp, relativePos);
	}

	private void moveAim(float axis, Transform gunPoint, float speed, float minZ, float maxZ) {
		float changeZ_1 = axis;
		Quaternion nextRotation_1 = gunPoint.localRotation;
		Vector3 euler1 = nextRotation_1.eulerAngles;
		euler1.z = Mathf.Clamp (euler1.z + changeZ_1 * speed, minZ, maxZ);
		gunPoint.localRotation = Quaternion.Euler (euler1);
	}



}
