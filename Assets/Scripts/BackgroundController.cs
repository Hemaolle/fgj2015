using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	public GameObject backgroundTestPrefab;
	public float rangeX = 100f;
	public float rangeY = 100f;
	public float rangeZ = 100f;

	public int count = 100;

	public float minScale = 1f;
	public float maxScale = 100f;

	void Start() {
		if (backgroundTestPrefab != null) {
			for (int i=0; i<count; i++) {
				Vector3 randomPos = new Vector3(Random.Range(-rangeX, rangeX),Random.Range(-rangeY, rangeY),Random.Range(-rangeZ, rangeZ));
				randomPos += transform.position;

				GameObject o = (GameObject) Instantiate(backgroundTestPrefab, randomPos, Quaternion.identity);
				float scale = Random.Range(minScale, maxScale);
				o.transform.localScale = new Vector3(scale, scale, scale);

			}
		}
	}
}
