using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class HealthZeroRecycler : MonoBehaviour {

	private Health _health;

	void Awake() {
		_health = GetComponent<Health>();
		_health.healthZero += HandlehealthZero;
	}

	void HandlehealthZero (HealthEvent e)
	{
		gameObject.SetActive(false);
	}
}
