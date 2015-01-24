using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

    public Health healthToMonitor;
    public PlayerMovement playerMovement;
    public GameObject [] enableOnGameOver;

    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        healthToMonitor.healthZero += GameOver;
	}
	
    void GameOver (HealthEvent e)
    {
        gameOver = true;
        playerMovement.enabled = false;
        foreach(GameObject enablee in enableOnGameOver) {
            enablee.SetActive(true);
        }
    }

    void Update() {

        if (gameOver && Input.GetKey("space"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}