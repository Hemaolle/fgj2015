using UnityEngine;
using System.Collections;

/// <summary>
/// Chooses a random location defined by a bunch of box collider 2ds and spawns and object there.
/// 
/// Not finished
/// </summary>
public class RandomPositionSpawner : MonoBehaviour {

    public BoxCollider2D [] spawnAreas;

    private float [] surfaceAreas;

	// Use this for initialization
	void Start () {

        surfaceAreas = new float[spawnAreas.Length];

	    // Calculate the surface areas
        for (int i = 0; i < spawnAreas.Length; i++)
        {
            Vector2 size = spawnAreas[i].size;
            Vector2 scale = spawnAreas[i].transform.lossyScale;
            Vector2 spawnAreaDimensions = new Vector2(scale.x * size.x, scale.y * size.x);
            //Debug.Log(spawnAreaSize);
            surfaceAreas[i] = spawnAreaDimensions.x * spawnAreaDimensions.y;
        }

        // Choose a spawnArea so that the possibility is relative to the surface area of the spawnArea

        // Choose a random point inside chosen spawnArea

        // Spawn the object there
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
