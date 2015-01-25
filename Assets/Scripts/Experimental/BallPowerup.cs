using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallPowerup : MonoBehaviour {

	public UnityLayer correctLayer;
	public UnityLayer enemyLayer;

	public PlayerType player;

	public float duration = 5f;
	public int amountStartPowerUp = 5;
	public int currentAmount = 0;

	private PlayerShoot3 playerShooter;
	private int ownCount = 0;
	private int enemyCount = 0;

	private List<Collider> bullets = new List<Collider>();

	void Awake() {
		playerShooter = GameObject.FindObjectOfType<PlayerShoot3> ();
	}

	void Update() {
		currentAmount = ownCount - enemyCount;
		if (currentAmount == 5) {
			startPowerUp();
		}
	}

	private void startPowerUp() {
		if (player == PlayerType.Player1) {
			playerShooter.IsFireRate1PoweredUp = true;
		} else if (player == PlayerType.Player2) {
			playerShooter.IsFireRate2PoweredUp = true;
		}

		foreach (Collider c in bullets) {

			c.gameObject.SetActive(false);

			ownCount = 0;
			enemyCount = 0;
		}

		print ("start " + player);

		Invoke ("stopPowerUp", duration);
	}

	private void stopPowerUp() {
		if (player == PlayerType.Player1) {
			playerShooter.IsFireRate1PoweredUp = false;
		} else if (player == PlayerType.Player2) {
			playerShooter.IsFireRate2PoweredUp = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other) {
			if (other.gameObject.layer == correctLayer.layer) {
				ownCount += 1;
			} else if (other.gameObject.layer == enemyLayer.layer) {
				enemyCount += 1;
			}
			bullets.Add(other);
		} 
	}

	void OnTriggerExit(Collider other) {
		if (other) {
			if (other.gameObject.layer == correctLayer.layer) {
				ownCount -= 1;
			} else if (other.gameObject.layer == enemyLayer.layer) {
				enemyCount -= 1;
			}
			bullets.Remove(other);
		} 
	}
}
