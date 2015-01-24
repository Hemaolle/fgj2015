using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

    public Health healthToMonitor;
    public PlayerMovement playerMovement;
    public PauseGame pauser;

	// Use this for initialization
	void Start () {
        healthToMonitor.healthZero += GameOver;
	}
	
    void GameOver (HealthEvent e)
    {
        pauser.Pause();
        pauser.unPaused += () => {
            Application.LoadLevel(Application.loadedLevel); };
    }
}