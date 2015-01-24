using UnityEngine;

public class Health : MonoBehaviour {
	public delegate void HealthEventHook(HealthEvent e);
	public event HealthEventHook healthChange = delegate {};
	public event HealthEventHook healthZero = delegate {};
	public event HealthEventHook healthZeroCleanUp = delegate {};
	
	public float maxHealth;
	private float _currentHealth;
	public float CurrentHealth
	{
		get{return _currentHealth;}
	}
	
	private string _lastModifierTag = "";
	private bool _isDead = false;
	
	void Start() 
	{
		_currentHealth = maxHealth;
	}
	
	void OnEnable() {
		_isDead = false;
		modifyHealth(maxHealth, "reset");
	}
	
	public void modifyHealth(float amount, string modifierTag) 
	{
		_currentHealth = Mathf.Clamp(_currentHealth+amount, 0, maxHealth);
		
		HealthEvent healthChangeEvent = new HealthEvent("HealthChange");
		healthChangeEvent.tags.Add(modifierTag);
		_lastModifierTag = modifierTag;
		healthChange(healthChangeEvent);
		
		checkHealthReachZero();
	}
	
	private void checkHealthReachZero() 
	{
		if ( _currentHealth == 0 && !_isDead ) 
		{
			HealthEvent healthZeroEvent = new HealthEvent("HealthZero");
			healthZeroEvent.tags.Add(_lastModifierTag);
			healthZero(healthZeroEvent);
			healthZeroCleanUp(healthZeroEvent);
			_isDead = true;
		}
	}
}
