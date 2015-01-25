using UnityEngine;
using System.Collections;

public class PressAnyKeyToLoadScene : MonoBehaviour {

    public string sceneName;
	
	// Update is called once per frame
	void Update () {
	    if (Input.anyKey)
            Application.LoadLevel(sceneName);
	}
}
