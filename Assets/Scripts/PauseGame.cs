using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public delegate void PauseEventHook();
    public event PauseEventHook unPaused = delegate {};

    public GameObject [] enableOnPause;
    public string unPauseKey;

    private PlayerMovement playerMovement;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        playerMovement = Transform.FindObjectOfType<PlayerMovement>();
	}
	
    public void Pause() {
        PauseUnPause(true);
    }

    void Update() {
        if (paused && Input.GetKey(unPauseKey))
        {
            PauseUnPause(false);
            unPaused();
        }
    }

    void PauseUnPause(bool paused) {
        this.paused = paused;
        playerMovement.enabled = !paused;
        foreach(GameObject enablee in enableOnPause) {
            enablee.SetActive(paused);
        }
    }
}
