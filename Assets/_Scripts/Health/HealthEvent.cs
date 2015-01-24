using System.Collections.Generic;

public class HealthEvent {
	public string name;
	public List<string> tags = new List<string>();
	
	public HealthEvent() {
		
	}
	
	public HealthEvent(string name) {
		this.name = name;
	}
}