using UnityEngine;
using System.Collections;

public class HealthPowerup : MonoBehaviour {

    public UnityLayer pickerLayer;
    public float healthAmount = 5;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer == pickerLayer.layer)
        {
            collider.GetComponent<Health>().modifyHealth(healthAmount, LayerMask.LayerToName(pickerLayer.layer));
            Destroy(gameObject);
        }
    }
}
