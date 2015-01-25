using UnityEngine;
using System.Collections;

public class DontDestroyOnLevelLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
            Destroy(gameObject);
        GameObject.DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
