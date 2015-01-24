using UnityEngine;
using System;

[Serializable]
public class UnityTag {
	public bool isEnabled = true;

	[SerializeField]
	private string _tag;
	public string tag {
		get {
			if (isEnabled)
				return _tag;
			else
				return null;
		}
		set {
			_tag = value;
		}
	}
}
