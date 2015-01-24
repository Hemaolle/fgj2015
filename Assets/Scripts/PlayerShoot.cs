using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

	public GameObject bulletPrefab1;
	public GameObject bulletPrefab2;

	public Transform gunPoint1;
	public Transform gunPoint2;

	public float bulletSpeed = 10f;
	public float fireRate = 1f;

    public float baseDamage = 1f;

    private float _player1Damage;
    private float _player2Damage;

	private float _timer1 = 0f;
	private float _timer2 = 0f;

    void Start() {
        _player1Damage = baseDamage;
        _player2Damage = baseDamage;
    }

	void Update() {
		if (Input.GetAxis ("Player1Shoot") > 0) {
			if (_timer1 > 1f / fireRate) {
				shoot(bulletPrefab1, gunPoint1);
				_timer1 = 0f;
			}

		}

		if (Input.GetAxis ("Player2Shoot") > 0) {
			if (_timer2 > 1f / fireRate) {
				shoot(bulletPrefab2, gunPoint2);
				_timer2 = 0f;
			}
		}

		_timer1 += Time.deltaTime;
		_timer2 += Time.deltaTime;	
	}

	private void shoot(GameObject bulletPrefab, Transform gunPoint) {
		//print (gunPoint.InverseTransformDirection (Vector3.forward));
		GameObject o = (GameObject) Instantiate(bulletPrefab, gunPoint.position, Quaternion.identity);
		o.rigidbody.AddForce(gunPoint.TransformDirection(Vector3.up) * bulletSpeed, ForceMode.Force);
        o.transform.Rotate(gunPoint.eulerAngles);


	}



}
