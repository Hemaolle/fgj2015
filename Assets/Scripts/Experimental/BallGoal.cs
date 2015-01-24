using UnityEngine;
using System.Collections;

public class BallGoal : MonoBehaviour {

	public UnityLayer correctLayer;
	public UnityLayer enemyLayer;

	public PlayerType player;

	private int ownCount = 0;
	private int enemyCount = 0;


	void Update() {
		PlayerScore.Instances [player].Score = ownCount - enemyCount;
	}

	void OnTriggerEnter(Collider other) {
		if (other) {
			if (other.gameObject.layer == correctLayer.layer) {
				ownCount += 1;
			} else if (other.gameObject.layer == enemyLayer.layer) {
				enemyCount += 1;
			}

		} 
	}

	void OnTriggerExit(Collider other) {
		if (other) {
			if (other.gameObject.layer == correctLayer.layer) {
				ownCount -= 1;
			} else if (other.gameObject.layer == enemyLayer.layer) {
				enemyCount -= 1;
			}
			
		} 
	}
}
