using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject [] enableOnGameOver;
    public PauseGame pauser;

	void OnTriggerEnter(Collider collider) {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Player")
        {
            pauser.Pause();
            pauser.unPaused += () => {
                Application.LoadLevel(Application.loadedLevel); };
        }
    }
}
