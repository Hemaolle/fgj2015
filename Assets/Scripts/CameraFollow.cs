using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform objectToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(objectToFollow.position.x, objectToFollow.position.y, transform.position.z);
	}
}
