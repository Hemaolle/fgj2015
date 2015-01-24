using UnityEngine;
using System.Collections;

public class EnemyScore : MonoBehaviour {

	private Health _health;

	public UnityLayer player1Layer;
	public UnityLayer player2Layer;

	public float scoreAmount = 100f;
	
	void Awake() {
		_health = GetComponent<Health>();
		_health.healthZero += HandlehealthZero;
	}
	
	void HandlehealthZero (HealthEvent e)
	{
		if (e.tags.Contains(LayerMask.LayerToName(player1Layer.layer))) {
			PlayerScore.Instances[PlayerType.Player1].ModifyScore(scoreAmount);
		} else if (e.tags.Contains(LayerMask.LayerToName(player2Layer.layer))) {
			PlayerScore.Instances[PlayerType.Player2].ModifyScore(scoreAmount);
		} 
		
	}
}
