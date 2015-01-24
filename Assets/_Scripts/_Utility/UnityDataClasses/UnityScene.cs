using UnityEngine;
using System;

[Serializable]
public class UnityScene {
	[SerializeField]
	private string _sceneName;
	public string sceneName {
		get {
			return _sceneName;
		}
		set {
			_sceneName = value;
		}
	}
}
