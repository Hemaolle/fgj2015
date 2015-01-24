using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class HealthZeroExplosion : MonoBehaviour {

	private Health _health;
	
	public GameObject ExplosionFXPrefab;
	public float ExplosionRadius;
	public float ExplosionForce;

	void Awake() {
		_health = GetComponent<Health>();
		_health.healthZero += HandlehealthZero;
	}
	
	void HandlehealthZero (HealthEvent e)
	{
		if (ExplosionFXPrefab) {
			Instantiate(ExplosionFXPrefab, transform.position, Quaternion.identity);
		}

		Collider[] colliders = Physics.OverlapSphere (transform.position, ExplosionRadius);
		
		foreach (Collider c in colliders) {
			if (c && c.rigidbody) {
				c.rigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius, 0f);
			}
		}


	}
}
