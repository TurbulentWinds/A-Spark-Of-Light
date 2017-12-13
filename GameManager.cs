using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject[] toSpawn;

	public GameObject bottomLeft;
	public GameObject topRight;

	public float spawnTime = 4.0f;

	void Start () {
		InvokeRepeating ("Spawn", 0.0f, spawnTime);
	}

	void Spawn () {

		Transform tr = topRight.transform;
		Transform bl = bottomLeft.transform;

		Vector3 spawnLocation = new Vector3 (Random.Range (tr.position.x, bl.position.x), Random.Range (bl.position.y, tr.position.y), 0);

		//Debug.Log("Spawn Location: " + spawnLocation);

		float random = Random.Range (0.0f, 1.0f);

		if (random > 0.5f) {
			Instantiate(toSpawn[0], spawnLocation, Quaternion.identity);
		} else {
			Instantiate(toSpawn[1], spawnLocation, Quaternion.identity);
		}
	}
}
