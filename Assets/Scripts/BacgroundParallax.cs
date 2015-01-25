using UnityEngine;
using System.Collections;

public class BacgroundParallax : MonoBehaviour {

    public float parallaxRate = 0.05f;

    private Vector3 originalLocalPosition;
    private Vector3 originalParentPosition;   

	// Use this for initialization
	void Start () {
        originalLocalPosition = transform.localPosition;
        originalParentPosition = transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 parentDifference = transform.parent.position - originalParentPosition;
        transform.localPosition = originalLocalPosition - parentDifference * parallaxRate;
	}
}
