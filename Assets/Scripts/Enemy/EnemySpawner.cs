using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public BoxCollider left;
	public BoxCollider right;
	public BoxCollider top;
	public BoxCollider bottom;

	private BoxCollider[][] directions;

	public float spawnRate = 1f;

	private float _timer = 0f;

	void Start() {
		directions = new BoxCollider[][] {
			new BoxCollider[] { left, right },
			new BoxCollider[] { right, left },
			new BoxCollider[] { top, bottom },
			new BoxCollider[] { bottom, top }
		};
	}

	void Update() {
		

		if (_timer > 1f / spawnRate) {
			int direction = Random.Range(0,4);
			spawn(directions[direction][0],directions[direction][1]);
		}

		_timer += Time.deltaTime;


	}

	private void spawn(BoxCollider from, BoxCollider to) {
		int index = Random.Range (0, enemyPrefabs.Length);
		
		Vector3 startPos = from.transform.position + getRandomFromRange(from.bounds.extents);
		Vector3 endPos = to.transform.position + getRandomFromRange(to.bounds.extents);
		startPos.z = 0f;
		endPos.z = 0f;
		
		GameObject enemy = (GameObject)Instantiate (enemyPrefabs [index], startPos, Quaternion.identity);
		enemy.GetComponent<MoveOneDirection> ().direction = endPos - startPos;
		
		_timer = 0f;
	}

	private Vector3 getRandomFromRange(Vector3 ranges) {
		return new Vector3 (
			getRandomFromRange(ranges.x),
			getRandomFromRange(ranges.y),
			getRandomFromRange(ranges.z)
		);
	}

	private float getRandomFromRange(float range) {
		return Random.Range (-range, range);
	}
}
