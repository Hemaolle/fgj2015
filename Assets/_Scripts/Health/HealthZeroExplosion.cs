using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class HealthZeroExplosion : MonoBehaviour {

	private Health _health;
	
	public GameObject ExplosionFXPrefab;
	public float ExplosionRadius;
	public float ExplosionForce;

	public UnityLayer affectedLayer;

	void Awake() {
		_health = GetComponent<Health>();
		_health.healthZero += HandlehealthZero;
	}
	
	void HandlehealthZero (HealthEvent e)
	{
		if (ExplosionFXPrefab) {
			Instantiate(ExplosionFXPrefab, transform.position, Quaternion.identity);
		}

		Collider[] colliders = Physics.OverlapSphere (transform.position, ExplosionRadius, 1 << affectedLayer.layer);
		
		foreach (Collider c in colliders) {
			if (c && c.rigidbody) {
				c.rigidbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius, 0f);
			}
		}

		SoundEffectManager.playSoundEffect ("explosion");
	}
}
