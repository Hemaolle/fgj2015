using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public static Dictionary<PlayerType, PlayerScore> Instances = new Dictionary<PlayerType, PlayerScore>();

	public PlayerType player;
	public Text scoreText;
	public float Score;

	void Awake() {
		if (!Instances.ContainsKey(player))
        {
            Instances.Add(player, this);
        } else
        {
            Instances[player] = this;
        }
	}

	void Update() {
		scoreText.text = Score.ToString ("0");
	}

	public void ModifyScore(float amount) {
		Score += amount;
	}
}
