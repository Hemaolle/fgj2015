using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour {

	public float radius;
	public UnityLayer[] layers;
	public float force;

	void FixedUpdate()
	{
		int layerMask = 1;
		foreach(UnityLayer l in layers) {
			layerMask = layerMask | (1 << l.layer);
		}


		Collider[] colliders = Physics.OverlapSphere (transform.position, radius, layerMask);
		
		foreach (Collider c in colliders) {
			if (c && c.rigidbody) {
				Vector3 direction = c.transform.position - transform.position;
				c.rigidbody.AddForce(direction.normalized * force);
			}
		}
		
		
	}
}
