using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Slider healthSlider;
	public Health health;

	void Start() {
		healthSlider.minValue = 0;
		healthSlider.maxValue = health.maxHealth;
	}

	void Update() {
		healthSlider.value = health.CurrentHealth;
	}
}
