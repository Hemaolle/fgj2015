using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject [] enableOnGameOver;
    public PauseGame pauser;
    public string nextLevelName;
    public bool finalLevel;

	void OnTriggerEnter(Collider collider) {
        if (LayerMask.LayerToName(collider.gameObject.layer) == "Player")
        {
            if(finalLevel) {
                pauser.Pause();
                pauser.unPaused += () => {
                    Application.LoadLevel(nextLevelName); };
            }
            else {
                Application.LoadLevel(nextLevelName);
            }
        }
    }
}
