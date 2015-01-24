using UnityEngine;
using System.Collections;

public class OneWayDamageDetector : MonoBehaviour {

	public UnityTag damagerTag;
	public UnityLayer damagerLayer;
	
	private Health _health;
	
	void Start () {
		_health = GetComponent<Health>();
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.gameObject.layer == damagerLayer.layer) {
			takeDamage(otherCollider.GetComponent<HealthDamager>(), LayerMask.LayerToName(damagerLayer.layer));
			return;
		}
		
		if (otherCollider.CompareTag(damagerTag.tag)) {
			takeDamage(otherCollider.GetComponent<HealthDamager>(), damagerTag.tag);
			return;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == damagerLayer.layer) {
			takeDamage(collision.gameObject.GetComponent<HealthDamager>(), LayerMask.LayerToName(damagerLayer.layer));
			return;
		}
		
		if (collision.gameObject.CompareTag(damagerTag.tag)) {
			takeDamage(collision.gameObject.GetComponent<HealthDamager>(), damagerTag.tag);
			return;
		}
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		if (otherCollider.gameObject.layer == damagerLayer.layer) {
			takeDamage(otherCollider.GetComponent<HealthDamager>(), LayerMask.LayerToName(damagerLayer.layer));
			return;
		}
		
		if (otherCollider.CompareTag(damagerTag.tag)) {
			takeDamage(otherCollider.GetComponent<HealthDamager>(), damagerTag.tag);
			return;
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == damagerLayer.layer) {
			takeDamage(collision.gameObject.GetComponent<HealthDamager>(), LayerMask.LayerToName(damagerLayer.layer));
			return;
		}
		
		if (collision.gameObject.CompareTag(damagerTag.tag)) {
			takeDamage(collision.gameObject.GetComponent<HealthDamager>(), damagerTag.tag);
			return;
		}
	}
	
	private void takeDamage(HealthDamager damager, string modifierTag) {
		if (damager != null)
		{
			_health.modifyHealth(-damager.damage, modifierTag);
		}
	}
}
