﻿using UnityEngine;
using System.Collections;

public class bombSpawner : MonoBehaviour {
	// a public object array for which objects to spawn
	public GameObject obj;
	//min and max times for another spawn
	public float spawnMin = 3f;
	public float spawnMax = 2f;

	void Start () {
		//start spawn 
		Spawn ();
	}

	void Spawn(){
		//get random number
		float rand = Random.Range (0, 1000);
		//if random number is greater than 700 make a bomb
		if (rand > 700) {
			Instantiate (obj, transform.position, Quaternion.identity);
		}
		//invoke spawn at random time interval between min and max
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}
}
