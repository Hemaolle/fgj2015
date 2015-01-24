using UnityEngine;
using System;

[Serializable]
public class UnityLayer {
	public bool isEnabled;

	[SerializeField]
	private int _layer;
	
	public int layer 
	{
		get 
		{
			if (isEnabled)
				return _layer;
			else
				return -1;
		}
		set 
		{ 
			_layer = value;
		}
	}
}
